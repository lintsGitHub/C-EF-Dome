using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext中的三种加载模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddSchool();
            EagerLoad();
            Console.ReadKey();
        }
        /// <summary>
        /// 添加一个学校
        /// </summary>
        static void AddSchool() {
            using (EFDomeEntities context = new EFDomeEntities())
            {
                context.Database.Log = Console.WriteLine;
                context.School.Add(
                    new School { name="nf149" }
                    );
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 添加一个学生
        /// </summary>
        static void AddStudent()
        {
            using (EFDomeEntities context = new EFDomeEntities())
            {
                context.Database.Log = Console.WriteLine;
                context.Student.Add(new Student {
                    age= 13,
                    name = "lints",
                    SchoolID = 1
                });
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 默认使用的是延迟加载
        /// </summary>
        static void LazyLoad() {
            using (EFDomeEntities context = new EFDomeEntities())
            {
                context.Database.Log = Console.WriteLine;
                // 我们去数据库中找Student,里面并没有School对象 的信息
                var item = context.Student.FirstOrDefault();
                // 然后再去找School对象，如果我不访问这个School 对象就不会去数据库中找
               var school = item.School;
            }
        }

        /// <summary>
        /// 关闭延迟加载，使用显示加载
        /// </summary>
        static void ExplicitLoading()
        {
            using (EFDomeEntities context = new EFDomeEntities())
            {
                context.Database.Log = Console.WriteLine;
                //设置关闭延迟加载
                context.Configuration.LazyLoadingEnabled = false;

                // 我们去数据库中找Student,里面并没有School对象的信息，也就是School为null
                var item = context.Student.FirstOrDefault();

                //我们手动去将School 这个对象进行显示加载
                context.Entry(item).Reference(s => s.School).Load();
                //如果是集合可以使用
                //context.Entry(item).Collection(s => s.School).Load();

                var school = item.School;
            }
        }
        /// <summary>
        /// 立即加载
        /// </summary>
        static void EagerLoad() {
            using (EFDomeEntities context = new EFDomeEntities())
            {
                context.Database.Log = Console.WriteLine;
                //将懒加载去掉
                context.Configuration.LazyLoadingEnabled = false;
                //查询相关对象,可以链式操作
               var query = context.School.Include("Student").ToList();
            }
        }

    }
}
