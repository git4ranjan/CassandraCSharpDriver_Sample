// pluskal

using System;
using CassandraCSharpDriver_Sample.DAL.Interfaces;

namespace CassandraCSharpDriver_Sample.DAL.Entities
{
    public class User : IDataModel
    {
        public String Group { get; set; }
        public String Name { get; set; }
        public Guid Id { get; set; }

        public override String ToString()
        {
            return
                $"{nameof(this.Id)}: {this.Id}, {nameof(this.Name)}: {this.Name}, {nameof(this.Group)}: {this.Group}";
        }
    }
}