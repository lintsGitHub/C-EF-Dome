using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 爬虫dome
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Entities context = new Entities())
            {
                context.carimages.Add(new carimage
                {
                    carid = 1,
                    decription = "aa",
                    imgurl = "aa"
                });
                context.SaveChanges();
            }
        }
    }
}
