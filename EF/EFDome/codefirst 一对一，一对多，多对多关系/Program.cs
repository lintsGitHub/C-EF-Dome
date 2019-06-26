using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst_一对一_一对多_多对多关系
{
    class Program
    {
        static void Main(string[] args)
        {
            OneToOne();
            Console.ReadKey();
        }

        static void OneToOne() {
            using (SchoolDB context = new SchoolDB())
            {
                context.Database.Log = Console.WriteLine;
                context.Students.Add(new Student
                {
                    ID = 1,
                    Name = "lint"
                });
                context.SaveChanges();
            }
        }

    }
}
