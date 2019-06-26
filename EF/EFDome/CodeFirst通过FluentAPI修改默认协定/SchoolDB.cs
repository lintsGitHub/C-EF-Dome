using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst通过FluentAPI修改默认协定
{
    class SchoolDB:DbContext
    {
        public SchoolDB() : base("data source=.;initial catalog=SchoolDB2;integrated security=True")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entityConfig = modelBuilder.Entity<Student>();
            //修改表名
            entityConfig.ToTable("StudentTable");

            //使用map映射表,会在数据库中多出stu1, stu2表
            entityConfig.Map<Student>(c =>
            {
                c.Properties(s => new { s.Name });
                c.ToTable("stu1");
            }).Map<Student>(c =>
            {
                c.Properties(s => new { s.Name,s.StudentAddress });
                c.ToTable("stu2");
            });
            //获取到这个表的字段
           var stuProperty = entityConfig.Property(i => i.Name);
            //设置这个字段的一些配置
            stuProperty.HasColumnName("Name").HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
