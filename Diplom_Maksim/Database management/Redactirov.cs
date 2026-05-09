namespace diplom.Database_management
{
    public static class Redactirov
    {
        public static bool relact_Student(int id, string name)
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

        public static bool relact_Fakultet(int id, string name)
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

        public static bool relact_Vid_Gr(int id, string name)
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
