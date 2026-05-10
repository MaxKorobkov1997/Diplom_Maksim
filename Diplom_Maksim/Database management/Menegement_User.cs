using diplom;
using diplom.ta_ble;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplom_Maksim.Database_management
{
    public class Menegement_User
    {
        public void Add_user(string login, string password)
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

        public bool Prov_User ()
        {
            using (var context = new DBpodkl())
            {
                if (context.Users.Count() == 0)
                    return true;
                return false;
            }
        }

        public bool Loogin(string login, string password)
        {
            using (var context = new DBpodkl())
            {
                var users = context.Users.Where(o => o.Login == login && o.Password == password).Count();
                if (users > 0)
                    return true;
                return false;
            }
        }
    }
}
