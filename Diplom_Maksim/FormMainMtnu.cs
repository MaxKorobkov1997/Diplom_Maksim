using diplom;
using Templates;

namespace Diplom_Maksim
{

    public partial class FormMainMtnu : BorderLessForm
    {
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
            button6.Click += (c, e) => Close();
            button7.Click += (c, e) => WindowState = FormWindowState.Minimized;
            button1.Click += (c, e) => OpenChildForm(new Form1(), c);
            button2.Click += (c, e) => OpenChildForm(new Form2(), c);
            button3.Click += (c, e) => OpenChildForm(new Form3(), c);
            button4.Click += (c, e) => OpenChildForm(new Form4(), c);
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
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
