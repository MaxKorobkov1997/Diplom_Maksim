namespace Diplom_Maksim
{
    partial class Form6
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
            button6 = new Button();
            textBox4 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(button6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(499, 31);
            panel1.TabIndex = 14;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // button6
            // 
            button6.Location = new Point(458, 5);
            button6.Name = "button6";
            button6.Size = new Size(29, 23);
            button6.TabIndex = 2;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(154, 62);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 16;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(31, 124);
            button1.Name = "button1";
            button1.Size = new Size(199, 51);
            button1.TabIndex = 17;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Save;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(panel1);
            Name = "Form6";
            Text = "Form6";
            Load += Form6_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button6;
        private TextBox textBox4;
        private Label label1;
        private Button button1;
    }
}