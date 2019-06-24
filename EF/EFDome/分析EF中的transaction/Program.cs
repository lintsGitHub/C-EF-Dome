using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
                //开启一个事务,并将它设置为脏读，我们就可以避免死锁的一个问题(高并发的一个解决方案)
                var tran = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                //向控制台输出日志
                context.Database.Log = Console.WriteLine;
                var query = context.Classes.FirstOrDefault();
                context.SaveChanges();
                //提交一个事务
                tran.Commit();
            }
        }
        /// <summary>
        /// 比较完整的一个自定义事务提交方案
        /// </summary>
        static void TranDome4() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //开启一个事务,并将它设置为脏读，我们就可以避免死锁的一个问题(高并发的一个解决方案)
                using (var tran = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        //向控制台输出日志
                        context.Database.Log = Console.WriteLine;

                        //curd...

                        var query = context.Classes.FirstOrDefault();
                        context.SaveChanges();
                        //提交一个事务
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
        /// <summary>
        /// 我们还可以使用TransactionScope 的方式进行事务管理
        /// </summary>
        static void TranDome5()
        {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //开启一个事务
                using (var tran =new TransactionScope())
                {
                    try
                    {
                        //向控制台输出日志
                        context.Database.Log = Console.WriteLine;

                        //curd...

                        var query = context.Classes.FirstOrDefault();
                        context.SaveChanges();
                        //提交一个事务
                        tran.Complete();
                    }
                    catch (Exception ex)
                    {
                        //回滚
                        Transaction.Current.Rollback();
                    }
                }
            }
        }
    }
}
