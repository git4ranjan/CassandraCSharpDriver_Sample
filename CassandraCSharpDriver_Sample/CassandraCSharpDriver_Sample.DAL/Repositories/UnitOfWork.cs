using System;

namespace CassandraCSharpDriver_Sample.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public Int32 Complete() => throw new NotImplementedException();

        public void Dispose()
        {

        }
    }
}