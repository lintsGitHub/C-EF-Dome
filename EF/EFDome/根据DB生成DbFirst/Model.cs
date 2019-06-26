namespace 根据DB生成DbFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Models")
        {
            Database.SetInitializer<Model>(new DropCreateDatabaseModelChanges<Model>());
        }

        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
