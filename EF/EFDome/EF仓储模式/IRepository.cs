using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF仓储模式
{
   
        /// <summary>
        /// 仓储接口，定义一些常用的方法
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public interface IRepository<TEntity> :IEnumerable where TEntity : class
        {
           
           TEntity Add(TEntity entity);
           
           IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
           
           TEntity Attach(TEntity entity);
           TEntity Create();
           
           TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity;
           
            bool Equals(object obj);
           
           TEntity Find(params object[] keyValues);
           
           Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
           
           TEntity Remove(TEntity entity);
           
           IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);
           
        }
    
}
