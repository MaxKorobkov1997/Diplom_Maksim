using diplom;
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
    public partial class FormMainMtnu : Form
    {
        Font font = new Font("Microsoft Sans Serif", 14);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private Form activeForm;
        public FormMainMtnu()
        {
            InitializeComponent();
        }

        private void FormMainMtnu_Load(object sender, EventArgs e)
        {
            button1.Font = font;
            button2.Font = font;
            button3.Font = font;
            button4.Font = font;
            button5.Font = font;
            button6.Font = font;
            button7.Font = font;
            button6.Text = "X";
            button7.Text = "_";
            FormBorderStyle = FormBorderStyle.None;
            label1.Text = Static.user;
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form2(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form4(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Enabled = false;

            Form5 f = new Form5();
            f.FormClosed += SecondForm5_FormClosed;
            f.Show();
        }

        private void SecondForm5_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Enabled = true;

            // Отписываемся от события
            Form5 secondForm = (Form5)sender;
            label1.Text = Static.user;
            secondForm.FormClosed -= SecondForm5_FormClosed;
        }
    }
}
