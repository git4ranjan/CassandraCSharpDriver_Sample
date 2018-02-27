// pluskal

using Cassandra.Mapping;
using CassandraCSharpDriver_Sample.DAL.Entities;

namespace CassandraCSharpDriver_Sample.DAL
{
    public class EntityMappings : Mappings
    {
        public EntityMappings()
        {
            // Define mappings in the constructor of your class
            // that inherits from Mappings
            this.For<User>()
                .TableName("users")
                .PartitionKey(u => u.Id)
                .Column(u => u.Id, cm => cm.WithName("id"));
        }
    }
}