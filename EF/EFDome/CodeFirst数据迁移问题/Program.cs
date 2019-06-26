using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst数据迁移问题
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model db = new Model())
            {
                db.Database.Log = Console.WriteLine;
                db.Students.Add(new Student {
                    StuName="123456789"
                });
                db.SaveChanges();
            }
        }
    }
}
