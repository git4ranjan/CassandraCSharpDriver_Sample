// pluskal

using System;
using Cassandra;
using Cassandra.Mapping;
using CassandraCSharpDriver_Sample.DAL;

namespace CassandraCSharpDriver_Sample.Cli
{
    /// <summary>
    ///     Sample base on official documentation
    ///     https://github.com/datastax/csharp-driver
    ///     https://docs.datastax.com/en/developer/csharp-driver/3.4/features/components/linq/
    /// </summary>
    internal class Program
    {
        private static void Main(String[] args)
        {
            // Connect to the demo keyspace1 on our cluster running at 127.0.0.1
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                // .WithCredentials("cassandra", "cassandrapwd")
                //.WithDefaultKeyspace(KeySpace.Replace("\"", ""))
                .Build();

            MappingConfiguration.Global.Define<EntityMappings>();
        }
    }
}