using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq在EF中的Lambda表达式方法
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void sele() {

            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                context.StudentSets.Select(i => i);
            }

        }
    }
}
