using Microsoft.EntityFrameworkCore;
using SampleApp1.Data;
using TryAtSoftware.Randomizer.Core.Helpers;

namespace SampleApp1.Core.Tests.Utilities.Fixtures
{
    public sealed class MySqlDatabaseFixture : IDisposable
    {
        private readonly SampleDbContext _dbContext;
        private bool disposedValue;

        public MySqlDatabaseFixture()
        {
            var randomName = RandomizationHelper.GetRandomString(10, RandomizationHelper.LOWER_CASE_LETTERS);
            this.ConnectionString = $"Server=localhost;Database=test_{randomName};Uid=root;Pwd=root;";

            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            optionsBuilder.UseMySQL(this.ConnectionString);

            this._dbContext = new SampleDbContext(optionsBuilder.Options);
            this._dbContext.Database.EnsureCreated();
        }

        public string ConnectionString { get; }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._dbContext.Database.EnsureDeleted();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
