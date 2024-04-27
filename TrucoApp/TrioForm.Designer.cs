namespace TrucoApp
{
    partial class TrioForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            fecharButton = new Button();
            salvarButton = new Button();
            panel2 = new Panel();
            sortearCheckBox = new CheckBox();
            entidadeTextBox = new TextBox();
            label2 = new Label();
            nomeTextBox = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(fecharButton);
            panel1.Controls.Add(salvarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 141);
            panel1.Name = "panel1";
            panel1.Size = new Size(252, 35);
            panel1.TabIndex = 0;
            // 
            // fecharButton
            // 
            fecharButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fecharButton.Location = new Point(170, 6);
            fecharButton.Name = "fecharButton";
            fecharButton.Size = new Size(75, 23);
            fecharButton.TabIndex = 1;
            fecharButton.Text = "Fechar";
            fecharButton.UseVisualStyleBackColor = true;
            // 
            // salvarButton
            // 
            salvarButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            salvarButton.Location = new Point(89, 6);
            salvarButton.Name = "salvarButton";
            salvarButton.Size = new Size(75, 23);
            salvarButton.TabIndex = 0;
            salvarButton.Text = "Salvar";
            salvarButton.UseVisualStyleBackColor = true;
            salvarButton.Click += salvarButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(sortearCheckBox);
            panel2.Controls.Add(entidadeTextBox);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(nomeTextBox);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 141);
            panel2.TabIndex = 1;
            // 
            // sortearCheckBox
            // 
            sortearCheckBox.AutoSize = true;
            sortearCheckBox.Checked = true;
            sortearCheckBox.CheckState = CheckState.Checked;
            sortearCheckBox.Location = new Point(12, 116);
            sortearCheckBox.Name = "sortearCheckBox";
            sortearCheckBox.Size = new Size(63, 19);
            sortearCheckBox.TabIndex = 4;
            sortearCheckBox.Text = "Sortear";
            sortearCheckBox.UseVisualStyleBackColor = true;
            // 
            // entidadeTextBox
            // 
            entidadeTextBox.Location = new Point(12, 82);
            entidadeTextBox.Name = "entidadeTextBox";
            entidadeTextBox.Size = new Size(229, 23);
            entidadeTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 2;
            label2.Text = "Entidade";
            // 
            // nomeTextBox
            // 
            nomeTextBox.Location = new Point(12, 27);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new Size(229, 23);
            nomeTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // TrioForm
            // 
            AcceptButton = salvarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = fecharButton;
            ClientSize = new Size(252, 176);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TrioForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button fecharButton;
        private Button salvarButton;
        private TextBox entidadeTextBox;
        private Label label2;
        private TextBox nomeTextBox;
        private Label label1;
        private CheckBox sortearCheckBox;
    }
}