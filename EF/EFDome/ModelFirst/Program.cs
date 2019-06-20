using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFDomeContainer DBContent = new EFDomeContainer() )
            {
                DBContent.StudentSet.Add(new Student() {
                    Name ="lint",
                    Age ="21"
                });
                DBContent.SaveChanges();
            }
        }
    }
}
