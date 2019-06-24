using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq在EF中的Lambda表达式方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //sele();
            // groupby();
            seleWhere();
        }
        /// <summary>
        /// 简单的查询
        /// </summary>
        static void sele() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
               var list = context.StudentSets.Select(i => i);
            }
        }
        /// <summary>
        /// 分组查询
        /// </summary>
        static void groupby() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
               var query = context.Classes.GroupBy(i => i.ClassName);
                foreach (var item in query)
                {
                    var key = item.Key;
                    var list = item.ToList();
                }
            }
        }
        /// <summary>
        /// 多表分组查询
        /// </summary>
        static void groupjoin() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //第一个参数要连接的类
                //第二个参数 ，第三个参数， 两表关联
                //第三个参数 返回数据
                var query = context.StudentSets.GroupJoin(context.Classes, (StudentSet s) => s.Id, (Class a) => a.Id, (s, list) => new {
                    s.Name,
                    list
                });
                var lists = query.ToList();
            }
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        static void seleWhere() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                var query = context.StudentSets.Where(i => i.Id > 5000).ToList();
            }
        }
        /// <summary>
        /// OrderBy 排序
        /// </summary>
        static void seleOrder() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                //升序，根据ID， 我们可以通过链式操作，方法都是使用了构建者模式
                var query = context.StudentSets.Where(i => i.Id > 5000).OrderBy(i => i.Id).ToList(); 
                // 降序 根据ID
                var list = context.StudentSets.Where(i => i.Id > 5000).OrderByDescending(i => i.Id).ToList(); 
              
            }
        }
        /// <summary>
        /// join 内连接查询
        /// </summary>
        static void seleJoin() {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                var query = context.Classes.Join(context.StudentSets, (Class c) => c.Id, (StudentSet s) => s.Id, (c, s) => new
                {
                    c,
                    s
                });

                var list = query.ToList();
            }
        }

        /// <summary>
        /// Linq 方法链式操作
        /// </summary>
        static void seleChain()
        {
            using (SchoolDBEntities context = new SchoolDBEntities())
            {
                var query = context.Classes.Join(context.StudentSets, (Class c) => c.Id, (StudentSet s) => s.Id, (c, s) => new
                {
                    c,
                    s
                }).Where(i => i.c.Id > 1000).GroupBy(i => i.s.Name);

                var list = query.ToList();
            }
        }

    }
}
