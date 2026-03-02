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
        FormMainMtnu formMainMtnu;

        public Form5(FormMainMtnu formMainMtnu)
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.formMainMtnu = formMainMtnu;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
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
                    formMainMtnu.label1.Text = Static.user;
                    formMainMtnu.button5.Text = "Выйти";
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
    }
}
