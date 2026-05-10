using diplom;
using diplom.ta_ble;

namespace Diplom_Maksim
{
    public class Menegement_Student
    {
        public bool Add_student(string fio, string pasport, string Document_Soc_Gr = "none")
        {
            using (var context = new DBpodkl())
            {
                var users = context.Students.Where(o => o.Name == fio).Count();
                if (users == 0)
                {
                    var Joorn = new Student()
                    {
                        Name = fio,
                        Pasport = pasport,
                        Document_Soc_Gr = Document_Soc_Gr
                    };

                    context.Students.Add(Joorn);
                    context.SaveChanges();
                    return true;
                }
                else
                    MessageBox.Show("такой пользватель уже существует");
                return false;
            }
        }

        public string Delit_student(int a)
        {
            string student = "";
            using (var context = new DBpodkl())
            {
                var users = context.Students.Where(o => o.Id == a).FirstOrDefault();
                if (users != null)
                {
                    student = users.Name;
                    context.Students.Remove(users);
                    context.SaveChanges();
                }
            }
            return student;
        }

        public List<Student> otk_student()
        {
            List<Student> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Students.ToList();
            }
            return dt;
        }

        public void Delit_jurnal(int a)
        {
            while (true)
            {
                using (var context = new DBpodkl())
                {
                    var users = context.Jurnals.Where(o => o.Id_Neme == a).FirstOrDefault();
                    if (users != null)
                    {
                        context.Jurnals.Remove(users);
                        context.SaveChanges();
                    }
                    else break;
                }
            }
        }

        public bool relact_Student(int id, string name)
        {
            try
            {
                using (DBpodkl context = new DBpodkl())
                {
                    var users = context.Students.Where(o => o.Id == id).FirstOrDefault();
                    users.Name = name;
                    bool a = true;
                    context.SaveChanges();
                    var jur_user = context.Jurnals.Where(o => o.Id_Neme == id).ToList();
                    foreach (var user in jur_user)
                        user.VidGr = name;
                    context.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
