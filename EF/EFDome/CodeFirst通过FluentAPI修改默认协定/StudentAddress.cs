using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst通过FluentAPI修改默认协定
{
    class StudentAddress
    {
        public int ID { get; set; }

        public String Address { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
