using System;

namespace Life
{
    internal class InfectionModel
    {
        public const int Healthy = 0;
        public const int Infected = 1;
        public const int Immune = 2;

        private static readonly Random Random = new Random();

        private readonly int size;
        private readonly int[,] states;
        private readonly int[,] timers;

        public int Size => size;

        // Открытый конструктор, создаёт начальное состояние с заражённой центральной клеткой
        public InfectionModel(int size)
        {
            if (size <= 0 || size % 2 == 0)
                throw new ArgumentException("Размер поля должен быть положительным нечетным числом.");

            this.size = size;
            states = new int[size, size];
            timers = new int[size, size];

            int center = size / 2;
            states[center, center] = Infected;
            timers[center, center] = 0;
        }

        // Закрытый конструктор для создания следующего поколения
        private InfectionModel(int size, int[,] states, int[,] timers)
        {
            this.size = size;
            this.states = states;
            this.timers = timers;
        }

        public int GetState(int row, int column) => states[row, column];
        public int GetTimer(int row, int column) => timers[row, column];

        // Вычисляет следующее состояние всей сетки
        public InfectionModel CalculateNextState()
        {
            int[,] nextStates = new int[size, size];
            int[,] nextTimers = new int[size, size];

            // Копируем текущие состояния и таймеры
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    nextStates[r, c] = states[r, c];
                    nextTimers[r, c] = timers[r, c];
                }
            }

            // Обновляем собственное развитие каждой клетки (заражение -> иммунитет -> здоровье)
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (states[r, c] == Infected)
                    {
                        int newTimer = timers[r, c] + 1;
                        if (newTimer >= 6)
                        {
                            nextStates[r, c] = Immune;
                            nextTimers[r, c] = 0;
                        }
                        else
                        {
                            nextStates[r, c] = Infected;
                            nextTimers[r, c] = newTimer;
                        }
                    }
                    else if (states[r, c] == Immune)
                    {
                        int newTimer = timers[r, c] + 1;
                        if (newTimer >= 4)
                        {
                            nextStates[r, c] = Healthy;
                            nextTimers[r, c] = 0;
                        }
                        else
                        {
                            nextStates[r, c] = Immune;
                            nextTimers[r, c] = newTimer;
                        }
                    }
                    else // Здоровая
                    {
                        nextStates[r, c] = Healthy;
                        nextTimers[r, c] = 0;
                    }
                }
            }

            // Распространяем инфекцию от текущих заражённых клеток
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (states[r, c] == Infected && timers[r, c] < 6)
                    {
                        // Проверяем всех 8 соседей
                        for (int dr = -1; dr <= 1; dr++)
                        {
                            for (int dc = -1; dc <= 1; dc++)
                            {
                                if (dr == 0 && dc == 0) continue;
                                int nr = r + dr;
                                int nc = c + dc;
                                if (nr >= 0 && nr < size && nc >= 0 && nc < size)
                                {
                                    // Заразить можно только здоровые клетки
                                    if (states[nr, nc] == Healthy)
                                    {
                                        if (Random.NextDouble() < 0.5)
                                        {
                                            nextStates[nr, nc] = Infected;
                                            nextTimers[nr, nc] = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return new InfectionModel(size, nextStates, nextTimers);
        }
    }
}