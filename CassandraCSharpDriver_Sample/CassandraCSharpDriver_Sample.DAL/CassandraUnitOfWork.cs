// pluskal

using System;
using System.Threading.Tasks;
using Cassandra;
using CassandraCSharpDriver_Sample.DAL.Interfaces;

namespace CassandraCSharpDriver_Sample.DAL
{
    public abstract class CassandraUnitOfWork : IUnitOfWork
    {
        protected CassandraUnitOfWork(ISession session)
        {
            this.Session = session;
        }

        public ISession Session { get; }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Session?.Dispose();
        }
    }
}