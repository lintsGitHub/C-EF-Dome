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
                //添加
                db.MyEntities.Add(new MyEntity {
                    Name = "111",
                    Id = 1
                });
                //删除
                var item = db.MyEntities.FirstOrDefault();

                db.Entry(item).State = System.Data.Entity.EntityState.Added;

                db.MyEntities.Remove(item);

                db.SaveChanges();
            }
        }
    }
}
