using SampleApp1.Core.Tests.Utilities.Fixtures;
using Xunit;

namespace SampleApp1.Core.Tests.Utilities.Collections
{
    [CollectionDefinition(Name)]
    public class MySqlDatabaseCollection : ICollectionFixture<MySqlDatabaseFixture>
    {
        public const string Name = "my_sql_database";
    }
}
