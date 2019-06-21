using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq基础
{
    class Program
    {
        static void Main(string[] args)
        {
            //// from xxx in xxx select
            //seleStu();

            //seleStuWhere();
            //seleStuGroup();
            //seleStuOrder();

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //using (SchoolDBEntities context = new SchoolDBEntities())
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        context.StudentSets.Add(new StudentSet {
            //            Name = "lint"+i,
            //            Age = "21"
            //        });

            //        context.Classes.Add(new Classes {
            //            stuID = ""+i,
            //            ClassName = "147"+i,
            //            ClassNum = "147"+i
            //        });
            //    }
            //    context.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);

            seleLet();
            Console.ReadKey();
        }
        /// <summary>
        /// from xxx in xxxx  select 
        /// </summary>
        static void seleStu() {
            using (SchoolDBEntities dbContext = new SchoolDBEntities())
            {
                var query = from s in dbContext.StudentSets
                            select s;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
        /// <summary>
        /// from xxx in xxxx  select 加上 where 进行数据筛选 
        /// </summary>
        static void seleStuWhere()
        {
            using (SchoolDBEntities dbContext = new SchoolDBEntities())
            {
                var query = from s in dbContext.StudentSets
                            where s.Name != "123"
                            select s;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
        /// <summary>
        /// from xxx in xxxx  select group by  加上分组
        /// </summary>
        static void seleStuGroup()
        {
            using (SchoolDBEntities dbContext = new SchoolDBEntities())
            {
                var query = from s in dbContext.StudentSets
                            group s by s.Name
                            into s  // k , v 结构  Dictionary<string,List<Student>>
                            select s;

                foreach (var item in query)
                {
                    var key = item.Key;

                    var value = item.ToList();
                }
            }
        }

        /// <summary>
        /// from xxx in xxxx  select group by  加上分组, orderby 排序
        /// </summary>
        static void seleStuOrder()
        {
            using (SchoolDBEntities dbContext = new SchoolDBEntities())
            {
                var query = from s in dbContext.StudentSets
                            group s by s.Name
                            into s  // k , v 结构  Dictionary<string,List<Student>>
                            orderby s.Key  // 默认升序 //ascending 升序  //descending 降序
                            select s;

                foreach (var item in query)
                {
                    var key = item.Key;

                    var value = item.ToList();
                }
            }
        }
        /// <summary>
        /// 多表连接查询
        /// </summary>
        static void seleJoin() {

            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                var query = from s in context.StudentSets
                            join g in context.Classes
                            on s.Id equals g.Id  // 两个数据类型要一致
                            select new { s, g };
                var list = query.ToList();
            }
        }
        /// <summary>
        /// 使用let 临时变量
        /// </summary>
        static void seleLet() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                var query = from s in context.StudentSets
                            let len = s.Name.Length
                            select new { s ,len = len};
                //Console.WriteLine();
                var list = query.ToList();
            }
        }

    }
}
