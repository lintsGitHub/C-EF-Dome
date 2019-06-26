namespace 根据DB生成DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? SchoolID { get; set; }

        public int? age { get; set; }

        public virtual School School { get; set; }
    }
}
