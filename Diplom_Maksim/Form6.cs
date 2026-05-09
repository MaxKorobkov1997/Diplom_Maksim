using diplom.Database_management;
using System.Runtime.InteropServices;

namespace Diplom_Maksim
{
    public partial class Form6 : Form
    {
        int id;
        string name1, table;

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
            if (table == "Student")
                label1.Text = "Фио";
            else if (table == "Fakultet")
                label1.Text = "Факультеn";
            else if (table == "Vid_Gr")
                label1.Text = "Вид группы";
            textBox4.Text = name1;
            FontContol fontContol = new FontContol();
            fontContol.SetAllControlsFont(Controls);
        }
        private void Save(object sender, EventArgs e)
        {
            switch (table)
            {
                case "Student": 
                    Redactirov.relact_Student(id, textBox4.Text);
                    break;
                case "Fakultet":
                    Redactirov.relact_Fakultet(id, textBox4.Text);
                    break;
                case "Vid_Gr":
                    Redactirov.relact_Vid_Gr(id, textBox4.Text);
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
    }
}
