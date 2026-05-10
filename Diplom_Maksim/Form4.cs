using diplom;
using diplom.ta_ble;
using Diplom_Maksim.Database_management;
using System.Runtime.InteropServices;

namespace Diplom_Maksim
{
    public partial class Form4 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        List<Vid> vids;

        Menegement_Vidgr menegement_Vidgr;

        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Static.user != "Гость")
                {
                    int id1 = e.RowIndex;
                    string id = vids[id1].Id.ToString();
                    int a = Convert.ToInt32(id);
                    if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {

                        if (MessageBox.Show("Удалить эту строку " + a, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                        {
                            menegement_Vidgr.Delit_vidgr(a);
                            if (MessageBox.Show("Удалить эту строку " + a + " в таблице журнал", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                                menegement_Vidgr.Delit_jurnal(a);
                        }

                    }
                    else
                    {
                        string name = vids[id1].vid.ToString();
                        Enabled = false;
                        if (name != null)
                        {
                            Form6 f = new Form6(a, name, "Vid_Gr");
                            f.FormClosed += SecondForm6_FormClosed;
                            f.Show();
                        }
                    }
                    otkritie();
                }
            }
            catch
            {
                MessageBox.Show("Ни првильный вопрос");
            }
        }

        private void SecondForm6_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Активируем главную форму обратно
            Enabled = true;

            // Отписываемся от события
            Form6 secondForm = (Form6)sender;
            secondForm.FormClosed -= SecondForm6_FormClosed;
            otkritie() ;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            menegement_Vidgr = new Menegement_Vidgr();
            FontContol fontContol = new FontContol();
            fontContol.SetAllControlsFont(Controls);
            dataGridView1.ReadOnly = true;
            otkritie();
        }

        private void otkritie()
        {
            try
            {
                vids = menegement_Vidgr.otk_vidgr();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = vids;
                DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
                newColumn.HeaderText = "Новый столбец"; // Заголовок
                newColumn.Name = "newColumn"; // Название столбца
                newColumn.Text = "Удалить";
                newColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(newColumn); // Добавляем столбец к DataGridView
                dataGridView1.Columns[1].HeaderText = "Группа";
                dataGridView1.Columns[0].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Static.user != "Гость")
                {
                    menegement_Vidgr.Add_vid(textBox1.Text);
                    otkritie();
                }
                else
                    MessageBox.Show("Пожалуйста войдите в акаунт");
            }
            catch
            {
                otkritie();
            }
        }
    }
}
