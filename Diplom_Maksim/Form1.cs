using diplom;
using diplom.Database_management;
using diplom.ta_ble;

namespace Diplom_Maksim
{
    public partial class Form1 : Form
    {
        string path = "documents";
        List<Jurnal> jurnals;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.ReadOnly = true;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Combobox();
            otkritie1();
            dataGridView1.Font = Static.font;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = Static.font;
            comboBox2.Font = Static.font;
            comboBox3.Font = Static.font;
        }

        private void otkritie1()
        {
            try
            {
                jurnals = otkritie_tb.Otk_jurnal();
                dataGridView1.Columns.Clear();
                var tb = jurnals.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Id_Neme,
                    e.Fakultet,
                    e.Id_Fakultet,
                    e.VidGr,
                    e.Id_VidGr
                }).ToList();
                dataGridView1.DataSource = tb;
                DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
                newColumn.HeaderText = "Новый столбец"; // Заголовок
                newColumn.Name = "newColumn"; // Название столбца
                newColumn.Text = "Удалить";
                newColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(newColumn); // Добавляем столбец к DataGridView
                dataGridView1.Columns[1].HeaderText = "Имя";
                dataGridView1.Columns[2].HeaderText = "id";
                dataGridView1.Columns[3].HeaderText = "Факультет";
                dataGridView1.Columns[4].HeaderText = "Id факультета";
                dataGridView1.Columns[5].HeaderText = "Группа";
                dataGridView1.Columns[6].HeaderText = "Id ввида группы";
                dataGridView1.Columns[0].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Combobox()
        {
            try
            {
                comboBox1.Font = Static.font;
                comboBox1.DataSource = otkritie_tb.otk_student();
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Name";
                comboBox1.SelectedIndex = 0;
                comboBox2.Font = Static.font;
                comboBox2.DataSource = otkritie_tb.otk_faculteet();
                comboBox2.ValueMember = "Id";
                comboBox2.DisplayMember = "Fakultets";
                comboBox2.SelectedIndex = 0;
                comboBox3.Font = Static.font;
                comboBox3.DataSource = otkritie_tb.otk_vidgr();
                comboBox3.ValueMember = "Id";
                comboBox3.DisplayMember = "vid";
                comboBox3.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Static.user != "Гость")
                {
                    if (comboBox1.Text == "")
                        MessageBox.Show("Выберите имя");
                    if (comboBox2.Text == "")
                        MessageBox.Show("Выберите факультет");
                    if (comboBox3.Text == "")
                        MessageBox.Show("Выберите социальную группу");
                    else
                    {
                        add_bd.Add_jurnal(comboBox1.Text, (int)comboBox1.SelectedValue, comboBox2.Text, (int)comboBox2.SelectedValue, comboBox3.Text, (int)comboBox3.SelectedValue);
                        otkritie1();
                    }
                }
                else
                    MessageBox.Show("Пожалуйста войдите в акаунт");
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
                int a = jurnals[(int)e.RowIndex].Id;
                if (Static.user != "Гость")
                {
                    if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {

                        if (MessageBox.Show("Удалить эту строку " + a, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                            Delit.Delit_jurnal(a);
                    }
                    otkritie1();
                }
            }
            catch
            {
                MessageBox.Show("Ни првильный вопрос");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchAndHighlightRows(textBox1.Text);
        }
        private void SearchAndHighlightRows(string searchText)
        {
            dataGridView1.CurrentCell = null;
            // 1. Предварительная очистка выделения и проверка входных данных
            // Используем foreach для более чистого синтаксиса
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
            }

            // Если строка поиска пуста, нет смысла продолжать
            if (string.IsNullOrEmpty(searchText))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    row.Visible = true;
                return;
            }

            // 2. Основной цикл поиска
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Пропускаем последнюю "новую" строку, если она отображается пользователю
                if (row.IsNewRow) continue;

                bool foundInRow = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    // 3. Улучшенная проверка: убеждаемся, что значение ячейки не равно null
                    if (cell.Value != null)
                    {
                        // 4. Используем ToLowerInvariant() для сравнения без учета регистра
                        // (это более эффективно, чем создание нового StringComparison)
                        string cellValue = cell.Value.ToString();
                        if (cellValue.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) != -1)
                        {
                            foundInRow = true;
                            break; // Нашли совпадение в этой строке, можно идти к следующей строке
                        }
                    }
                }

                if (foundInRow)
                {
                    //row.Selected = true;
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
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

