using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst通过DataAnnotations来修改默认协定
{
    [Table("StudentTest")]
    public class Student
    {
        [Key]
        [Column("StudentID")]
        public int StudentKey { get; set; }
        [Required]
        [MaxLength(50)]
        public string  Name { get; set; }

        [ConcurrencyCheck]
        public string Email { get; set; }
        [NotMapped]
        [Timestamp]
        public byte[] thing { get; set; }

    }
}
