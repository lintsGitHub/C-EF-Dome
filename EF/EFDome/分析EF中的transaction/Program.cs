using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 分析EF中的transaction
{
    class Program
    {
        static void Main(string[] args)
        {

            TranDome3();
            Console.ReadKey();
        }
        /// <summary>
        /// 测试SaveChanges方法是否进行事务开启，提交等操作
        /// </summary>
        static void TranDome() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //将Database中的日志输出到控制台中 
                context.Database.Log = Console.WriteLine;
                context.Classes.Add(new Classes {
                    stuID = "1",
                    ClassName = "hello",
                    ClassNum = "10086"
                });
                context.Classes.Add(new Classes
                {
                    stuID = "1",
                    ClassName = "helloword",
                    ClassNum = "100861"
                });

                context.SaveChanges();
            }
        }
        /// <summary>
        /// select 操作中 SaveChanges 并没有产生事务
        /// </summary>
        static void TranDome2() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                context.Database.Log = Console.WriteLine;
                var query = context.Classes.FirstOrDefault();
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 自己开启一个事务来自定义化操作
        /// </summary>
        static void TranDome3()
        {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //开启一个事务
                var tran = context.Database.BeginTransaction();
                //向控制台输出日志
                context.Database.Log = Console.WriteLine;
                var query = context.Classes.FirstOrDefault();
                context.SaveChanges();
                //提交一个事务
                tran.Commit();
            }
        }
    }
}
