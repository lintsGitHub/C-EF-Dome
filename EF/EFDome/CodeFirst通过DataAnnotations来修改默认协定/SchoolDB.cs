using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst通过DataAnnotations来修改默认协定
{
    class SchoolDB :DbContext
    {
        public SchoolDB():base("data source=.;initial catalog=SchoolDB1;integrated security=True")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

      
        public DbSet<Student> Students { get; set; }


    }
}
