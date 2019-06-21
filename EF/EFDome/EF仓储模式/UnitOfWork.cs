using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF仓储模式
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void saveChage()
        {
            throw new NotImplementedException();
        }
    }
}
