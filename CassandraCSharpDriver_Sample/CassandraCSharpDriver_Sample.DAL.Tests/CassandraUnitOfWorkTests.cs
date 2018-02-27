// pluskal

using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using CassandraCSharpDriver_Sample.DAL.Entities;
using CassandraCSharpDriver_Sample.DAL.Interfaces;
using CassandraCSharpDriver_Sample.DAL.Repositories;
using Xunit;

namespace CassandraCSharpDriver_Sample.DAL.Tests
{
    public class CassandraUnitOfWorkTestsFixtureData
    {
        public CassandraUnitOfWorkTestsFixtureData()
        {
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").WithDefaultKeyspace(nameof(BaseRepositoryTests)).Build();
            cluster.ConnectAndCreateDefaultKeyspaceIfNotExists();
            this.UnitOfWork = new CassandraUnitOfWork(cluster, new EntityMappings());
        }

        public CassandraUnitOfWork UnitOfWork { get; set; }
    }


    public class CassandraUnitOfWorkTests: IClassFixture<CassandraUnitOfWorkTestsFixtureData>
    {
        private readonly IRepositoryReader<Foo> _repositoryReader;
        private readonly IRepositoryWriter<Foo> _repositoryWriter;
        private readonly IUnitOfWork _unitOfWork;

        public CassandraUnitOfWorkTests(CassandraUnitOfWorkTestsFixtureData fixtureData)
        {
            this._unitOfWork = fixtureData.UnitOfWork;

            var repository = new CassandraRepository<Foo>(this._unitOfWork);
            this._repositoryWriter = repository;
            this._repositoryReader = repository;
        }

        [Fact(Skip = "NotImplemented")]
        public void CommitsTransactionCorrectly()
        {
            //Arrange
            var initialCount = this._repositoryReader.GetAll().Count();
            var foo1 = new Foo {Id = Guid.NewGuid()};
            var foo2 = new Foo {Id = Guid.NewGuid()};

            //Act
            this._unitOfWork.BeginTransaction();
            this._repositoryWriter.Insert(foo1);
            this._unitOfWork.SaveChanges();
            this._repositoryWriter.Insert(foo2);
            this._unitOfWork.SaveChanges();
            this._unitOfWork.Commit();

            //Assert
            var all = this._repositoryReader.GetAll();
            Assert.Equal(initialCount + 2, all.Count());
            Assert.Contains(foo1, all);
            Assert.Contains(foo2, all);
        }

        [Fact]
        public void DisposeWorksCorrectly()
        {
            //Arrange
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            var unitOfWork = new CassandraUnitOfWork(cluster, new EntityMappings());
            var repository = new CassandraRepository<Foo>(this._unitOfWork);

            //Act
            repository.Insert(new Foo {Id = Guid.NewGuid()});
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();

            //Assert
        }

        [Fact(Skip = "NotImplemented")]
        public void RollsBackTransactionCorrectly()
        {
            //Arrange
            var initialCount = this._repositoryReader.GetAll().Count();
            var foo1 = new Foo {Id = Guid.NewGuid()};
            var foo2 = new Foo {Id = Guid.NewGuid()};

            //Act
            this._unitOfWork.BeginTransaction();
            this._repositoryWriter.Insert(foo1);
            this._unitOfWork.SaveChanges();
            this._repositoryWriter.Insert(foo2);
            this._unitOfWork.SaveChanges();
            this._unitOfWork.Rollback();

            //Assert
            var all = this._repositoryReader.GetAll().ToArray();
            Assert.Equal(initialCount, all.Count());
            Assert.DoesNotContain(foo1, all);
            Assert.DoesNotContain(foo2, all);
        }

        [Fact]
        public void SavesChanges()
        {
            //Arrange
            var initialCount = this._repositoryReader.GetAll().Count();
            var foo1 = new Foo {Id = Guid.NewGuid()};
            var foo2 = new Foo {Id = Guid.NewGuid()};

            //Act
            this._repositoryWriter.Insert(foo1);
            this._repositoryWriter.Insert(foo2);
            this._unitOfWork.SaveChanges();

            //Assert
            var all = this._repositoryReader.GetAll().ToArray();
            Assert.Equal(initialCount + 2, all.Count());
            Assert.Contains(foo1, all);
            Assert.Contains(foo2, all);
        }

        [Fact]
        public async Task SavesChangesAsync()
        {
            //Arrange
            var initialCount = this._repositoryReader.GetAll().Count();
            var foo1 = new Foo {Id = Guid.NewGuid()};
            var foo2 = new Foo {Id = Guid.NewGuid()};

            //Act
            this._repositoryWriter.Insert(foo1);
            this._repositoryWriter.Insert(foo2);
            await this._unitOfWork.SaveChangesAsync();

            //Assert
            var all = this._repositoryReader.GetAll().ToArray();
            Assert.Equal(initialCount + 2, all.Count());
            Assert.Contains(foo1, all);
            Assert.Contains(foo2, all);
        }
    }
}