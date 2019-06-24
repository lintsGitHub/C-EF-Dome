using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
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
            //ESQL();
            RSQL();
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
        /// <summary>
        /// RSQL 
        /// </summary>
        static void RSQL() {
            // 这个就是App.config中的数据库连接串
            using (var con = new EntityConnection("name=SchoolDBEntities"))
            {
                //打开连接
                con.Open();
                //通过连接创建一个命令对象
                EntityCommand cmd = con.CreateCommand();
                //设置要执行的SQL语句或存储过程
                cmd.CommandText = "select value s from SchoolDBEntities.StudentSets as s";
                //定义一个接收字典
                Dictionary<int, string> dic = new Dictionary<int, string>();

                using (EntityDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess|System.Data.CommandBehavior.CloseConnection))
                {
                    while (rd.Read())
                    {
                        int a = rd.GetInt32(0);
                        string b = rd.GetString(1);
                        dic.Add(a, b);
                    }
                }
            }

        }

    }
}
