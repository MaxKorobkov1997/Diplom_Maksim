using diplom.Database_management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
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

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form6(int id1, string name2, string tab)
        {
            FormBorderStyle = FormBorderStyle.None;
            id = id1;
            name1 = name2;
            table = tab;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button6.Text = "X";
            button7.Text = "_"; 
            switch (table)
            {
                case "Student":
                    name = name1.Split();
                    Label label1 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 40),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Имя"
                    };
                    textBox1 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 40),
                        Text = name[0],
                        Font = font,
                    };
                    Label label2 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 70),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Фамилия"
                    };
                    textBox2 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 70),
                        Text = name[1],
                        Font = font,
                    };
                    Label label3 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 100),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Отчество"
                    };
                    textBox3 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 100),
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
                case "Fakultet":
                    Label label4 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 40),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Факультет"
                    };
                    textBox1 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 40),
                        Text = name1,
                        Font = font,
                    };
                    Controls.Add(label4);
                    Controls.Add(textBox1);
                    break;
                case "Vid_Gr":
                    Label label5 = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 40),
                        Margin = new Padding(2, 0, 2, 0),
                        Name = "label3",
                        Size = new Size(65, 13),
                        TabIndex = 28,
                        Font = font,
                        Text = "Вид группы"
                    };
                    textBox1 = new System.Windows.Forms.TextBox
                    {
                        Location = new Point(110, 40),
                        Text = name1,
                        Font = font,
                    };
                    Controls.Add(label5);
                    Controls.Add(textBox1);
                    break;
            }
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button
            {
                Location = new Point(90, 130),
                Text = "Сохранить изменения",
            };
            Controls.Add(button1);
            button1.Click += Save;
        }
        private void Save(object sender, EventArgs e)
        {
            switch (table)
            {
                case "Student":
                    string fio = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
                    Redactirov.relact_Student(id, fio);
                    break;
                case "Fakultet":
                    Redactirov.relact_Fakultet(id, textBox1.Text);
                    break;
                case "Vid_Gr":
                    Redactirov.relact_Vid_Gr(id, textBox1.Text);
                    break;
            }
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
