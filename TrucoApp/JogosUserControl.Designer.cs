namespace TrucoApp
{
    partial class JogosUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            sortearButton = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(sortearButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 24);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(244, 0);
            button1.Name = "button1";
            button1.Size = new Size(133, 23);
            button1.TabIndex = 4;
            button1.Text = "Exportar para Excel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // sortearButton
            // 
            sortearButton.Location = new Point(0, 0);
            sortearButton.Name = "sortearButton";
            sortearButton.Size = new Size(100, 23);
            sortearButton.TabIndex = 0;
            sortearButton.Text = "Sortear Etapa";
            sortearButton.UseVisualStyleBackColor = true;
            sortearButton.Click += sortearButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(573, 188);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(573, 188);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // button2
            // 
            button2.Location = new Point(106, 0);
            button2.Name = "button2";
            button2.Size = new Size(132, 23);
            button2.TabIndex = 5;
            button2.Text = "Excluir última etapa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // JogosUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "JogosUserControl";
            Size = new Size(573, 212);
            Load += TriosUserControl_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button sortearButton;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
    }
}
