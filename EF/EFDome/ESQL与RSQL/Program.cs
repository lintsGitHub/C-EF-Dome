using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESQL与RSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            ESQL();
        }


        /// <summary>
        /// ESQL简单使用
        /// </summary>
        static void ESQL() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //一个简单的查询语句 相当于数据库中的 select * from StudentSets
                string sql = "select Value s from SchoolDBEntities.StudentSets as s";
                // ESQL是直接是操作ObjectContext的
                var obj = (context as IObjectContextAdapter).ObjectContext;
                //执行查询语句
                 var student = obj.CreateQuery<StudentSets>(sql);
                var query = student.ToList();
                
            }
        }
        

    }
}
