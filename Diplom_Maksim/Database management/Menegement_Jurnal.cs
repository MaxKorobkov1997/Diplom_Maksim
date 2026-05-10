using diplom;
using diplom.ta_ble;

namespace Diplom_Maksim.Database_management
{
    public class Menegement_Jurnal
    {
        public List<Fakultet> otk_faculteet()
        {
            List<Fakultet> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Fakultets.ToList();
            }
            return dt;
        }

        public List<Vid> otk_vidgr()
        {
            List<Vid> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Vids.ToList();
            }
            return dt;
        }

        public void Add_jurnal(string name, int id_Name, string fakyltet, int id_Fakul, string vidgr, int id_vid)
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

        public void Delit_jurnal(int a)
        {
            using (var context = new DBpodkl())
            {
                var users = context.Jurnals.Where(o => o.Id == a).FirstOrDefault();
                if (users != null)
                {
                    context.Jurnals.Remove(users);
                    context.SaveChanges();
                }
            }
            
        }

        public List<Jurnal> Otk_jurnal()
        {
            List<Jurnal> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Jurnals.ToList();
            }
            return dt;
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
    }
}
