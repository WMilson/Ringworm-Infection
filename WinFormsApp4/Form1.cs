using System;
using System.Drawing;
using System.Windows.Forms;

namespace Life
{
    public partial class Form1 : Form
    {
        private InfectionModel currentModel;
        private int generation = 0;

        public Form1()
        {
            InitializeComponent();

            stepButton.Enabled = false;
            toggleTimerButton.Enabled = false;
            timer1.Interval = 500; // мс между автоматическими шагами
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int n) || n <= 0 || n % 2 == 0)
            {
                MessageBox.Show("Введите положительное нечетное число для размера поля.");
                textBox1.Clear();
                return;
            }

            if (n > 100)
            {
                MessageBox.Show("Размер поля не должен превышать 100.");
                textBox1.Clear();
                return;
            }

            currentModel = new InfectionModel(n);
            generation = 0;
            SetupGrid(n);
            RenderModel();

            stepButton.Enabled = true;
            toggleTimerButton.Enabled = true;
            toggleTimerButton.Text = "Старт";
            timer1.Enabled = false;
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            AdvanceGeneration();
        }

        private void toggleTimerButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            toggleTimerButton.Text = timer1.Enabled ? "Пауза" : "Старт";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AdvanceGeneration();
        }

        private void AdvanceGeneration()
        {
            if (currentModel == null) return;
            currentModel = currentModel.CalculateNextState();
            generation++;
            RenderModel();
        }

        private void SetupGrid(int n)
        {

            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            dataGridView1.ClearSelection();

            int cellSize = Math.Max(10, Math.Min(30, 500 / n));
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows[i].Height = cellSize;
                dataGridView1.Columns[i].Width = cellSize;
            }
        }

        private void RenderModel()
        {
            if (currentModel == null) return;

            int n = currentModel.Size;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    int state = currentModel.GetState(r, c);
                    Color color;
                    switch (state)
                    {
                        case InfectionModel.Infected:
                            color = Color.Red;
                            break;
                        case InfectionModel.Immune:
                            color = Color.LightBlue;
                            break;
                        default:
                            color = Color.White;
                            break;
                    }
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = color;
                }
            }

            this.Text = $"Модель инфекции - шаг {generation}";
        }
    }
}