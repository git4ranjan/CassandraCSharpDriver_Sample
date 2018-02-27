// pluskal

using System;

namespace CassandraCSharpDriver_Sample.DAL.Interfaces
{
    /// <summary>
    ///     Base interface for all data models in project
    /// </summary>
    public interface IDataModel
    {
        Guid Id { get; set; }
    }
}