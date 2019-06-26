using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst_一对一_一对多_多对多关系
{
    public class SchoolDB : DbContext
    {
        public SchoolDB():base("data source=.;initial catalog=SchoolDB;integrated security=True")
        {
                
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
