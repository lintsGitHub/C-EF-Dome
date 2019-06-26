using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst通过DataAnnotations来修改默认协定
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolDB context = new SchoolDB())
            {
                context.Database.Log = Console.WriteLine;

                var item = context.Students.FirstOrDefault();

                item.Name = "lii";

                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
