using diplom;
using System.Runtime.InteropServices;

namespace Diplom_Maksim
{
    public partial class FormMainMtnu : Form
    {
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
            label1.Font = Static.font;
            button1.Font = Static.font;
            button2.Font = Static.font;
            button3.Font = Static.font;
            button4.Font = Static.font;
            button5.Font = Static.font;
            button6.Font = Static.font;
            button7.Font = Static.font;
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
            if ((sender as Button).Text == "Войти")
            {
                OpenChildForm(new Form5(this), sender);
            }
            else
            {
                (sender as Button).Text = "Войти";
                Static.user = "Гость";
                label1.Text = Static.user;
            }
        }
    }
}
