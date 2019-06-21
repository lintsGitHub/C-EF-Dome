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
    /// 仓储接口实现类，实现具体方法
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Create()
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        TDerivedEntity IRepository<TEntity>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
