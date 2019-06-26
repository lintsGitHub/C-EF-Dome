using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst_一对一_一对多_多对多关系
{
    public class StudentAddress
    {
        
        public int ID { get; set; }

        public String  Address { get; set; }

        public ICollection<Student> Students  { get; set; }
    }
}
