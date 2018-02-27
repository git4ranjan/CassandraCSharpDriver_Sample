// pluskal

using System;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using CassandraCSharpDriver_Sample.DAL.Interfaces;

namespace CassandraCSharpDriver_Sample.DAL
{
    public abstract class CassandraUnitOfWork : IUnitOfWork
    {
        private static Boolean _setUpDone;

        protected CassandraUnitOfWork()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            this.Session = cluster.Connect();
            DoOneTimeSetUp();
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

        private static void DoOneTimeSetUp()
        {
            if (_setUpDone) return;

            MappingConfiguration.Global.Define<EntityMappings>();
            _setUpDone = true;
        }
    }
}