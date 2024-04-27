namespace TrucoApp
{
    partial class TrucoForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            triosUserControl2 = new TriosUserControl(_context);
            jogosUserControl2 = new JogosUserControl(_context);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(816, 493);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(triosUserControl2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(808, 465);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Trios";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(jogosUserControl2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(808, 465);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Jogos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // jogosUserControl2
            // 
            jogosUserControl2.Dock = DockStyle.Fill;
            jogosUserControl2.Location = new Point(3, 3);
            jogosUserControl2.Name = "jogosUserControl2";
            jogosUserControl2.Size = new Size(802, 459);
            jogosUserControl2.TabIndex = 0;
            // 
            // triosUserControl2
            // 
            triosUserControl2.Dock = DockStyle.Fill;
            triosUserControl2.Location = new Point(3, 3);
            triosUserControl2.Name = "triosUserControl2";
            triosUserControl2.Size = new Size(802, 459);
            triosUserControl2.TabIndex = 0;
            // 
            // TrucoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 493);
            Controls.Add(tabControl1);
            Name = "TrucoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TriosForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private JogosUserControl jogosUserControl2;
        private TriosUserControl triosUserControl2;
    }
}