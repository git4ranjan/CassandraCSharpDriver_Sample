using Cassandra.Mapping;

namespace CassandraCSharpDriver_Sample.DAL.Tests
{
    internal class EntityMappings : Mappings
    {
        public EntityMappings()
        {
            // Define mappings in the constructor of your class
            // that inherits from Mappings
            this.For<Foo>()
                .TableName("Foos")
                .PartitionKey(u => u.Id)
                .Column(u => u.Id, cm => cm.WithName("id"));
        }
    }
}