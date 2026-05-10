using diplom;
using diplom.ta_ble;

namespace Diplom_Maksim.Database_management
{
    internal class Menegement_Fakultet
    {
        public void Add_fakultet(string fakultrt)
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

        public void Delit_faculteet(int a)
        {
            using (var context = new DBpodkl())
            {
                var users = context.Fakultets.Where(o => o.Id == a).FirstOrDefault();
                if (users != null)
                {
                    context.Fakultets.Remove(users);
                    context.SaveChanges();
                }
            }
        }

        public List<Fakultet> otk_faculteet()
        {
            List<Fakultet> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Fakultets.ToList();
            }
            return dt;
        }

        public void Delit_jurnal(int a)
        {
            while (true)
            {
                using (var context = new DBpodkl())
                {
                    var users = context.Jurnals.Where(o => o.Id_Fakultet == a).FirstOrDefault();
                    if (users != null)
                    {
                        context.Jurnals.Remove(users);
                        context.SaveChanges();
                    }
                    else break;
                }
            }
        }

        public bool relact_Fakultet(int id, string name)
        {
            try
            {
                bool a = true;
                using (DBpodkl context = new DBpodkl())
                {
                    var users = context.Fakultets.Where(o => o.Id == id).FirstOrDefault();
                    users.Fakultets = name;
                    context.SaveChanges();
                    var jur_user = context.Jurnals.Where(o => o.Id_Fakultet == id).ToList();
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
