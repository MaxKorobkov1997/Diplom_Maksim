using diplom;
using Diplom_Maksim.Database_management;

namespace Diplom_Maksim
{
    public partial class Form5 : Form
    {
        FormMainMtnu formMainMtnu;
        Menegement_User user;
        public Form5(FormMainMtnu formMainMtnu)
        {
            InitializeComponent();
            this.formMainMtnu = formMainMtnu;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            user = new Menegement_User();
            FontContol fontContol = new FontContol();
            fontContol.SetAllControlsFont(Controls);
            
                if (user.Prov_User()) 
                    button2.Enabled = true;
                else button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (user.Loogin(textBox1.Text, textBox2.Text))
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

        private void button2_Click(object sender, EventArgs e)
        {
            user.Add_user(textBox1.Text, textBox2.Text);
        }
    }
}
