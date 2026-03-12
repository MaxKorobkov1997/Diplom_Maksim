namespace Diplom_Maksim
{
    partial class FormMainMtnu
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
            panel2 = new Panel();
            button7 = new Button();
            button6 = new Button();
            panelMenu = new Panel();
            button5 = new Button();
            label1 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Location = new Point(207, 23);
            panel2.Name = "panel2";
            panel2.Size = new Size(1030, 643);
            panel2.TabIndex = 2;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.Location = new Point(1170, 1);
            button7.Name = "button7";
            button7.Size = new Size(29, 23);
            button7.TabIndex = 1;
            button7.Text = "_";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(1205, 1);
            button6.Name = "button6";
            button6.Size = new Size(29, 23);
            button6.TabIndex = 0;
            button6.Text = "X";
            button6.UseVisualStyleBackColor = true;
            // 
            // panelMenu
            // 
            panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelMenu.BackColor = Color.Blue;
            panelMenu.Controls.Add(button5);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(button4);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(button1);
            panelMenu.Location = new Point(1, 23);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(206, 643);
            panelMenu.TabIndex = 0;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ButtonFace;
            button5.Location = new Point(97, 30);
            button5.Name = "button5";
            button5.Size = new Size(97, 40);
            button5.TabIndex = 11;
            button5.Text = "Войти";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(13, 38);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(3, 339);
            button4.Name = "button4";
            button4.Padding = new Padding(12, 0, 0, 0);
            button4.Size = new Size(200, 63);
            button4.TabIndex = 3;
            button4.Text = "Вид Группы";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(3, 270);
            button3.Name = "button3";
            button3.Padding = new Padding(12, 0, 0, 0);
            button3.Size = new Size(200, 63);
            button3.TabIndex = 2;
            button3.Text = "Факультет";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(0, 201);
            button2.Name = "button2";
            button2.Padding = new Padding(12, 0, 0, 0);
            button2.Size = new Size(200, 63);
            button2.TabIndex = 1;
            button2.Text = "Студенты";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(0, 132);
            button1.Name = "button1";
            button1.Padding = new Padding(12, 0, 0, 0);
            button1.Size = new Size(200, 63);
            button1.TabIndex = 0;
            button1.Text = "Журнал";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormMainMtnu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            BorderColor = Color.Black;
            ClientSize = new Size(1238, 654);
            Controls.Add(button7);
            Controls.Add(panel2);
            Controls.Add(button6);
            Controls.Add(panelMenu);
            Name = "FormMainMtnu";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "FormMainMtnu";
            Load += FormMainMtnu_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button button7;
        private Button button6;
        private Panel panelMenu;
        public Button button5;
        public Label label1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}