using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst_一对一_一对多_多对多关系
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }

        public ICollection<StudentAddress> StudentAddress { get; set; }

    }
}
