using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM提供的一些功能
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void EDMTran() {

            using (EFDomeEntities context = new EFDomeEntities())
            {
                //context.存储过程方法
            }
        }

    }
}
