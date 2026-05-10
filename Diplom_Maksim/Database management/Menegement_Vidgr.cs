using diplom;
using diplom.ta_ble;

namespace Diplom_Maksim.Database_management
{
    public class Menegement_Vidgr
    {
        public void Add_vid(string vidgr)
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

        public List<Vid> otk_vidgr()
        {
            List<Vid> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Vids.ToList();
            }
            return dt;
        }

        public void Delit_vidgr(int a)
        {
            using (var context = new DBpodkl())
            {
                var users = context.Vids.Where(o => o.Id == a).FirstOrDefault();
                if (users != null)
                {
                    context.Vids.Remove(users);
                    context.SaveChanges();
                }
            }
        }

        public void Delit_jurnal(int a)
        {
            while (true)
            {
                using (var context = new DBpodkl())
                {
                    var users = context.Jurnals.Where(o => o.Id_VidGr == a).FirstOrDefault();
                    if (users != null)
                    {
                        context.Jurnals.Remove(users);
                        context.SaveChanges();
                    }
                    else break;
                }
            }
        }

        public bool relact_Vid_Gr(int id, string name)
        {
            try
            {
                using (DBpodkl context = new DBpodkl())
                {
                    var users = context.Vids.Where(o => o.Id == id).FirstOrDefault();
                    if (users != null)
                        users.vid = name;
                    context.SaveChanges();
                    var jur_user = context.Jurnals.Where(o => o.Id_VidGr == id).ToList();
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
