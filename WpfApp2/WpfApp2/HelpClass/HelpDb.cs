using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.DataBase;

namespace WpfApp2.HelpClass
{
    class HelpDb
    {
        public static void Add<T>(T item) 
        {
            using(var db = new MedicDb()) 
            {
                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static void Remove<T>(T item)
        {
            using (var db = new MedicDb())
            {
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public static void Update<T>(T item)
        {
            using (var db = new MedicDb())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
