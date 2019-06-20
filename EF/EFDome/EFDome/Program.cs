using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDome
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建DbContext对象
            using (NFineBaseEntities nf = new NFineBaseEntities()) {
                nf.Students.Add(new Student()
                {
                    StuName = "lint"
                });
                // 将此上下文所做的更改到保存到数据库中
                nf.SaveChanges();
            }
        }
    }
}
