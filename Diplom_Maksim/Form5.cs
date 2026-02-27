using diplom;
using diplom.Database_management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Diplom_Maksim
{
    public partial class Form5 : Form
    {

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Form5()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button6.Text = "X";
            button7.Text = "_"; 
            using (var context = new DBpodkl())
            {
                int users = context.Users.Count();
                //MessageBox.Show(users.ToString());
                if (users == 0) button2.Enabled = true;
                else button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new DBpodkl())
            {
                var users = context.Users.Where(o => o.Login == textBox1.Text && o.Password == textBox2.Text).Count();
                if (users > 0)
                {
                    MessageBox.Show("Вы вошли");
                    Static.user = textBox1.Text;
                    Close();
                }
                else
                    MessageBox.Show("Такого пользоваля нет", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_bd.Add_user(textBox1.Text, textBox2.Text);
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
