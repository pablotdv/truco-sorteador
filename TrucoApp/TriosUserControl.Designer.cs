namespace TrucoApp
{
    partial class TriosUserControl
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
            editarButton = new Button();
            excluirButton = new Button();
            criarButton = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(editarButton);
            panel1.Controls.Add(excluirButton);
            panel1.Controls.Add(criarButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 24);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(243, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Exportar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // editarButton
            // 
            editarButton.Location = new Point(81, 0);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(75, 23);
            editarButton.TabIndex = 2;
            editarButton.Text = "Editar";
            editarButton.UseVisualStyleBackColor = true;
            editarButton.Click += editarButton_Click;
            // 
            // excluirButton
            // 
            excluirButton.Location = new Point(162, 0);
            excluirButton.Name = "excluirButton";
            excluirButton.Size = new Size(75, 23);
            excluirButton.TabIndex = 1;
            excluirButton.Text = "Excluir";
            excluirButton.UseVisualStyleBackColor = true;
            excluirButton.Click += salvarButton_Click;
            // 
            // criarButton
            // 
            criarButton.Location = new Point(0, 0);
            criarButton.Name = "criarButton";
            criarButton.Size = new Size(75, 23);
            criarButton.TabIndex = 0;
            criarButton.Text = "Criar";
            criarButton.UseVisualStyleBackColor = true;
            criarButton.Click += button1_Click;
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
            // TriosUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TriosUserControl";
            Size = new Size(573, 212);
            Load += TriosUserControl_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button excluirButton;
        private Button criarButton;
        private Panel panel2;
        private Button editarButton;
        private DataGridView dataGridView1;
        private Button button1;
    }
}
