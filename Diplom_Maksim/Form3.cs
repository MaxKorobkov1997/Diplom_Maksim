using diplom;
using diplom.Database_management;
using diplom.ta_ble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Templates;

namespace Diplom_Maksim
{
    public partial class Form3 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        List<Fakultet> fakultets;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Static.user != "Гость")
                {
                    add_bd.Add_fakultet(textBox1.Text);
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

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Font = Static.font;
            textBox1.Font = Static.font;
            button1.Font = Static.font;
            dataGridView1.ReadOnly = true;
            dataGridView1.Font = new Font("Microsoft Sans Serif", 14);
            otkritie();
        }

        private void otkritie()
        {
            try
            {
                fakultets = otkritie_tb.otk_faculteet();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource =fakultets;
                DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
                newColumn.HeaderText = "Новый столбец"; // Заголовок
                newColumn.Text = "Удалить";
                newColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(newColumn); // Добавляем столбец к DataGridView
                dataGridView1.Columns[1].HeaderText = "Факультет";
                dataGridView1.Columns[0].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Static.user != "Гость")
                {
                    int id1 = e.RowIndex;
                    string id = fakultets[id1].Id.ToString();
                    int a = Convert.ToInt32(id);
                    if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Удалить эту строку " + a, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                        {
                            Delit.Delit_faculteet(a);
                            if (MessageBox.Show("Удалить эту строку " + a + " в таблице журнал", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                            {
                                while (true)
                                {
                                    using (DBpodkl context = new DBpodkl())
                                    {
                                        Jurnal users1 = context.Jurnals.Where(o => o.Id_Fakultet == a).FirstOrDefault();
                                        if (users1 == null)
                                            break;
                                        Delit.Delit_jurnal(users1.Id);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string name = fakultets[id1].Fakultets.ToString();
                        Enabled = false;
                        if (name != null)
                        {
                            Form6 f = new Form6(a, name, "Fakultet");
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
