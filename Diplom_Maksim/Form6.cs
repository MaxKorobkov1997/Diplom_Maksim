using diplom.Database_management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Windows.Forms;

namespace Diplom_Maksim
{
    public partial class Form6 : Form
    {
        Font font = new Font("Microsoft Sans Serif", 14);
        int id;
        string[] name;
        string name1, table;
        TextBox textBox1, textBox2, textBox3;
        public Form6(int id1, string name2, string tab)
        {
            id = id1;
            name1 = name2;
            table = tab;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            switch (table)
            {
                case "fakultet":
                    name = name1.Split();
                    Label label1 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 20),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Имя"
                    };
                    textBox1 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 20),
                        Text = name[0],
                        Font = font,
                    };
                    Label label2 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 50),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Фамилия"
                    };
                    textBox2 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 50),
                        Text = name[1],
                        Font = font,
                    };
                    Label label3 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 80),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Отчество"
                    };
                    textBox3 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 80),
                        Text = name[2],
                        Font = font,
                    };
                    Controls.Add(label1);
                    Controls.Add(textBox1);
                    Controls.Add(textBox2);
                    Controls.Add(label2);
                    Controls.Add(textBox3);
                    Controls.Add(label3);
                    break;
            }
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button
            {
                Location = new Point(90, 110),
                Text = "Сохранить изменения",
            };
            Controls.Add(button1);
            button1.Click += Save;
        }
        private void Save(object sender, EventArgs e)
        {
            switch (table)
            {
                case "fakultet":
                    string fio = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
                    Redactirov.relact_Student(id, fio);
                    break;
            }
        }
    }
}
