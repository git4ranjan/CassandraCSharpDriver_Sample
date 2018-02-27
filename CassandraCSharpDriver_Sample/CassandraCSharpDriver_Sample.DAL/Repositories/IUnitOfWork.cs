// pluskal

using System;

namespace CassandraCSharpDriver_Sample.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Int32 Complete();
    }
}