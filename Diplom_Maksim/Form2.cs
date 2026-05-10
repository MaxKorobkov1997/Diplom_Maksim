using diplom;
using diplom.ta_ble;
using System.Data;
using System.Runtime.InteropServices;

namespace Diplom_Maksim
{
    public partial class Form2 : Form
    {
        string pathpasp, pathsoclic, pasp, soclic;
        List<Student> student;

        Menegement_Student Student_bd;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
            try
            {
                if (Static.user != "Гость")
                {
                    if (Student_bd.Add_student(path, pasp, soclic))
                    {
                        if (!Directory.Exists("documents" + "/" + path))
                            Directory.CreateDirectory("documents" + "/" + path);
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
                student = Student_bd.otk_student();
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
                int name = Convert.ToInt32(student[id1].Id.ToString());
                if (Static.user == "Гость")
                {
                    if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {

                        if (MessageBox.Show("Удалить эту строку " + name, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                        {
                            string student = Student_bd.Delit_student(name);
                            if (MessageBox.Show("Удалить эту строку " + name + " в таблице журнал", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                                Student_bd.Delit_jurnal(name);
                            string dirName = @$"{Directory.GetCurrentDirectory()}\documents\{student}";
                            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

                            if (dirInfo.Exists)
                            {
                                dirInfo.Delete(true);
                                MessageBox.Show("Каталог удалён");
                            }
                            else
                            {
                                MessageBox.Show("Каталог не существует");
                            }
                        }
                    }
                    else
                    {
                        string name_st = student[id1].Name.ToString();
                        Enabled = false;
                        if (name_st != null)
                        {
                            Form6 f = new Form6(name, name_st, "Student");
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
            otkritie();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Student_bd = new Menegement_Student();
            FontContol fontContol = new FontContol();
            fontContol.SetAllControlsFont(Controls);
            dataGridView1.ReadOnly = true;
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

        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
