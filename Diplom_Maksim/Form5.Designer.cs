namespace Diplom_Maksim
{
    partial class Form5
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
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 14.25F);
            textBox1.Location = new Point(444, 214);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 29);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Microsoft Sans Serif", 14.25F);
            button1.Location = new Point(420, 363);
            button1.Name = "button1";
            button1.Size = new Size(147, 62);
            button1.TabIndex = 1;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Font = new Font("Microsoft Sans Serif", 14.25F);
            textBox2.Location = new Point(444, 296);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 29);
            textBox2.TabIndex = 2;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Font = new Font("Microsoft Sans Serif", 14.25F);
            button2.Location = new Point(420, 440);
            button2.Name = "button2";
            button2.Size = new Size(147, 62);
            button2.TabIndex = 3;
            button2.Text = "Зарегистрироваться";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F);
            label1.Location = new Point(444, 187);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F);
            label2.Location = new Point(444, 269);
            label2.Name = "label2";
            label2.Size = new Size(76, 24);
            label2.TabIndex = 5;
            label2.Text = "Пароль";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 658);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form5";
            Text = "Form5";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}