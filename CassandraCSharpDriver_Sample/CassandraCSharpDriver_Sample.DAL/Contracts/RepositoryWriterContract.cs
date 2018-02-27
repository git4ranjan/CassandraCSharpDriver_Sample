// pluskal
#define CONTRACTS_FULL
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CassandraCSharpDriver_Sample.DAL.Interfaces;
using static System.Diagnostics.Contracts.Contract;

namespace CassandraCSharpDriver_Sample.DAL.Contracts
{
    [ContractClassFor(typeof(IRepositoryWriter<>))]
    internal sealed class RepositoryWriterContract<T> : IRepositoryWriter<T> where T : class, IDataModel, new()
    {
        T IRepositoryWriter<T>.Delete(Guid id)
        {
            return default(T);
        }

        T IRepositoryWriter<T>.Delete(T item)
        {
            //Requires<ArgumentNullException>(item != null, "item can't be null");
            Requires(item != null, "item can't be null");

            return default(T);
        }

        T IRepositoryWriter<T>.Insert(T item)
        {
            //Requires<ArgumentNullException>(item != null, "item can't be null");
            Requires(item != null, "item can't be null");

            return default(T);
        }

        IEnumerable<T> IRepositoryWriter<T>.InsertRange(IEnumerable<T> items)
        {
            //Requires<ArgumentNullException>(items != null, "items can't be null");
            Requires(items != null, "items can't be null");

            return default(IEnumerable<T>);
        }

        void IRepositoryWriter<T>.Update(T item)
        {
            //Requires<ArgumentNullException>(item != null, "item can't be null");
            Requires(item != null, "item can't be null");
        }
    }
}