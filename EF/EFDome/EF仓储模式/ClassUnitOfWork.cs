using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF仓储模式
{
     public class ClassUnitOfWork :UnitOfWork
    {
        public ClassUnitOfWork()
        {
            //初始化
        }
        public Repository<Student> Students { get; set; }
    }
}
