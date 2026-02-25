using System.Linq;

namespace diplom.Database_management
{
    internal static class Delit
    {
        public static void Delit_jurnal(int a)
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

        public static void Delit_student(int a)
        {
            using (var context = new DBpodkl())
            {
                var users = context.Students.Where(o => o.Id == a).FirstOrDefault();
                if (users != null)
                {
                    context.Students.Remove(users);
                    context.SaveChanges();
                }
            }
        }

        public static void Delit_faculteet(int a)
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

        public static void Delit_vidgr(int a)
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
    }
}
