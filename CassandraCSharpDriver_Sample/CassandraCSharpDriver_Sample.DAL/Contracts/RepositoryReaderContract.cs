﻿// pluskal

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CassandraCSharpDriver_Sample.DAL.Interfaces;

namespace CassandraCSharpDriver_Sample.DAL.Contracts
{
    [ContractClassFor(typeof(IRepositoryReader<>))]
    internal sealed class RepositoryReaderContract<T> : IRepositoryReader<T> where T : class, IDataModel, new()
    {
        IEnumerable<T> IRepositoryReader<T>.GetAll()
        {
            return default(IEnumerable<T>);
        }

        T IRepositoryReader<T>.GetById(Guid id)
        {
            return default(T);
        }
    }
}