namespace Life
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            initializeButton = new Button();
            stepButton = new Button();
            toggleTimerButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(12, 491);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 29);
            textBox1.TabIndex = 0;
            textBox1.Text = "25";
            // 
            // initializeButton
            // 
            initializeButton.Font = new Font("Segoe UI", 12F);
            initializeButton.Location = new Point(12, 528);
            initializeButton.Name = "initializeButton";
            initializeButton.Size = new Size(174, 47);
            initializeButton.TabIndex = 1;
            initializeButton.Text = "Инициализировать";
            initializeButton.UseVisualStyleBackColor = true;
            initializeButton.Click += initializeButton_Click;
            // 
            // stepButton
            // 
            stepButton.Font = new Font("Segoe UI", 12F);
            stepButton.Location = new Point(230, 539);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(75, 36);
            stepButton.TabIndex = 2;
            stepButton.Text = "Шаг";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // toggleTimerButton
            // 
            toggleTimerButton.Font = new Font("Segoe UI", 12F);
            toggleTimerButton.Location = new Point(230, 491);
            toggleTimerButton.Name = "toggleTimerButton";
            toggleTimerButton.Size = new Size(75, 36);
            toggleTimerButton.TabIndex = 3;
            toggleTimerButton.Text = "Старт";
            toggleTimerButton.UseVisualStyleBackColor = true;
            toggleTimerButton.Click += toggleTimerButton_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Location = new Point(343, 9);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(677, 566);
            dataGridView1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 587);
            Controls.Add(dataGridView1);
            Controls.Add(toggleTimerButton);
            Controls.Add(stepButton);
            Controls.Add(initializeButton);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Ожидается инициализация";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button initializeButton;
        private Button stepButton;
        private Button toggleTimerButton;
        private System.Windows.Forms.Timer timer1;
        private DataGridView dataGridView1;
    }
}
