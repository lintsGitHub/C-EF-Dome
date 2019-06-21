using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF仓储模式
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClassUnitOfWork DbContent = new ClassUnitOfWork())
            {
                DbContent.Students.Add(new Student {
                    stuID =1
                });
                DbContent.saveChage();
            }
        }
    }
}
