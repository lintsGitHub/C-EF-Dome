using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Student db = new Student())
            {
                db.MyEntities.Add(new MyEntity {
                    Name = "111",
                    Id = 1
                });
                db.SaveChanges();
            }
        }
    }
}
