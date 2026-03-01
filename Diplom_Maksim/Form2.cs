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

namespace Diplom_Maksim
{
    public partial class Form2 : Form
    {
        string pathpasp, pathsoclic, pasp, soclic;
        List<Student> student;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Form2()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
            try
            {
                if (Static.user != "Гость")
                {
                    if (add_bd.Add_student(path, pasp, soclic))
                    {
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        try
                        {
                            File.Copy(pathpasp, "documents" + "/" + path + "/" + pasp);
                            if (pathsoclic != "")
                                File.Copy(pathsoclic, "documents" + "/" + path + "/" + soclic);
                        }
                        catch { }
                        otkritie();
                    }

                }
                else
                    MessageBox.Show("Пожалуйста войдите в акаунт");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                otkritie();
            }
        }
        private void otkritie()
        {
            try
            {
                student = otkritie_tb.otk_student();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = student;
                DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
                newColumn.HeaderText = "Новый столбец"; // Заголовок
                newColumn.Name = "newColumn"; // Название столбца
                newColumn.Text = "Удалить";
                newColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(newColumn); // Добавляем столбец к DataGridView
                dataGridView1.Columns[1].HeaderText = "Фио";
                dataGridView1.Columns[0].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id1 = e.RowIndex;
                string id = student[id1].Id.ToString();
                int a = Convert.ToInt32(id);
                if (Static.user != "Гость")
                {
                    if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {

                        if (MessageBox.Show("Удалить эту строку " + a, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                        {
                            Delit.Delit_student(a);
                            if (MessageBox.Show("Удалить эту строку " + a + " в таблице журнал", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                                while (true)
                                {
                                    using (var context = new DBpodkl())
                                    {
                                        var users1 = context.Jurnals.Where(o => o.Id_Neme == a).FirstOrDefault();
                                        if (users1 == null)
                                            break;
                                        Delit.Delit_jurnal(users1.Id);
                                    }
                                }
                        }
                    }
                    else
                    {
                        string name = student[id1].Name.ToString();
                        Enabled = false;
                        if (name != null)
                        {
                            Form6 f = new Form6(a, name, "Student");
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

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.Font = new Font("Microsoft Sans Serif", 14);
            otkritie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pasp = Path.GetFileName(openFileDialog.FileName);
                pathpasp = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                soclic = Path.GetFileName(openFileDialog.FileName);
                pathsoclic = openFileDialog.FileName;
            }
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
