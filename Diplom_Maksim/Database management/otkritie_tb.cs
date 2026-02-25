using diplom.ta_ble;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace diplom.Database_management
{
    public static class otkritie_tb
    {
        public static List<Jurnal> Otk_jurnal()
        {
            List<Jurnal> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Jurnals.ToList();
            }
            return dt;
        }

        public static List<Student> otk_student()
        {
            List<Student> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Students.ToList();
            }
            return dt;
        }

        public static List<Fakultet> otk_faculteet()
        {
            List<Fakultet> dt;
            using (var context = new DBpodkl())
            {
                dt = context.Fakultets.ToList();
            }
            return dt;
        }

        public static List<Vid> otk_vidgr()
        {
            List<Vid> dt;
            using (var context = new DBpodkl())
            {
                dt =context.Vids.ToList();
            }
            return dt;
        }
    }
}
