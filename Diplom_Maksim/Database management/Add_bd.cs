using diplom.ta_ble;
using System.Linq;
using System.Windows.Forms;

namespace diplom.Database_management
{
    internal static class add_bd
    {
        public static void Add_jurnal(string name, int id_Name, string fakyltet, int id_Fakul, string vidgr, int id_vid)
        {
            using (var context = new DBpodkl())
            {
                var Joorn = new Jurnal()
                {
                    Name = name,
                    Id_Neme = id_Name,
                    Fakultet = fakyltet,
                    Id_Fakultet = id_Fakul,
                    VidGr = vidgr,
                    Id_VidGr = id_vid
                };
                context.Jurnals.Add(Joorn);
                context.SaveChanges();
            }
        }

        public static bool Add_student(string fio, string pasport, string Document_Soc_Gr = "none")
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

        public static void Add_fakultet(string fakultrt)
        {
            using (var context = new DBpodkl())
            {
                var Joorn = new Fakultet()
                {
                    Fakultets = fakultrt
                };
                context.Fakultets.Add(Joorn);
                context.SaveChanges();
            }
        }

        public static void Add_vid(string vidgr)
        {
            using (var context = new DBpodkl())
            {
                var vid = new Vid()
                {
                    vid = vidgr
                };
                context.Vids.Add(vid);
                context.SaveChanges();
            }
        }

        public static void Add_user(string login, string password)
        {
            using (var context = new DBpodkl())
            {
                var user = new User()
                {
                    Login = login,
                    Password = password
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
