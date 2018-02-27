// pluskal

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Data.Linq;
using CassandraCSharpDriver_Sample.DAL.Interfaces;

namespace CassandraCSharpDriver_Sample.DAL.Repositories
{
    public class CassandraRepository<TEntity> : IRepositoryReader<TEntity>, IRepositoryReaderAsync<TEntity>,
        IRepositoryWriter<TEntity>, IRepositoryWriterAsync<TEntity> where TEntity : class, IDataModel, new()
    {
        protected readonly ISession Session;

        public CassandraRepository(CassandraUnitOfWork unitOfWork)
        {
            this.Session = unitOfWork.Session;
            this.Table = this.Session.GetTable<TEntity>();

            this.Table.CreateIfNotExists(); //TODO is this a right place?
        }

        public Table<TEntity> Table { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Table.Execute();
        }

        public TEntity GetById(Guid id)
        {
            return this.Table.First(entity => entity.Id == id).Execute();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(Guid id)
        {
            var item = this.GetById(id);
            this.Delete(item);
            return item;
        }

        public TEntity Delete(TEntity item)
        {
            this.Table.Where(i => i.Id == item.Id)
                .Delete()
                .Execute();
            return item;
        }

        public TEntity Insert(TEntity item)
        {
            this.Table.Insert(item).Execute();
            return item;
        }

        public IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> items)
        {
            // Todo rewrite to appropriate bulk implementation
            var insertRange = items as TEntity[] ?? items.ToArray();
            foreach (var item in insertRange) this.Table.Insert(item);

            return insertRange;
        }

        public void Update(TEntity item)
        {
            this.Table.Where(i => i.Id == item.Id)
                .Select(_ => item)
                .Update()
                .Execute();
        }

        public Task<TEntity> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}