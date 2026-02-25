using diplom.ta_ble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
