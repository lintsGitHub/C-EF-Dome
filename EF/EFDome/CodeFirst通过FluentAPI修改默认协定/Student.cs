using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst通过FluentAPI修改默认协定
{
    class Student
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public ICollection<StudentAddress> StudentAddress { get; set; }
    }
}
