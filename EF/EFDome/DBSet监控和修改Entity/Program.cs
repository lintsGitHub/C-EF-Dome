using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSet监控和修改Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            DBEntityEntry();

        }
        /// <summary>
        /// 通过contextEntry来获取当前DbSet的一个状态
        /// </summary>
        static void DBEntityEntry() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
               var item = context.StudentSets.AsNoTracking().FirstOrDefault();

                item.Name = "lins";

                var contextEntry = context.Entry(item);

            }
        }
        /// <summary>
        /// 通过ChangeTracker属性获取到所有entry
        /// </summary>
        static void DBChangeTracker() {

            using (SchoolDBEntities context =new SchoolDBEntities())
            {
                context.Classes.Add(new Classes
                {
                    ClassName="aa"
                });

                context.Classes.FirstOrDefault();
                //获取entry集合
               var entryList = context.ChangeTracker.Entries();
                //遍历
                foreach (var item in entryList)
                {
                   var entiry = item.Entity;
                }
            }
        }
        /// <summary>
        /// 获取DBSet的一个Entry集合
        /// </summary>
        static void Local() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                context.Classes.Add(new Classes
                {
                    ClassName = "aa"
                });

                context.Classes.FirstOrDefault();

                foreach (var item in context.Classes.Local)
                {
                    var entry = context.Entry(item);
                }
            }
        }
    }
}
