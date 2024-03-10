using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleApp1.Core.Configuration;
using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Tests.Utilities.Collections;
using SampleApp1.Core.Tests.Utilities.Fixtures;
using SampleApp1.Data;
using Xunit;
using Xunit.Abstractions;

namespace SampleApp1.Core.Tests
{
    [Collection(MySqlDatabaseCollection.Name)]
    public class BaseTest : IDisposable
    {
        private ServiceProvider _rootServiceProvider;
        private IServiceScope _scope;
        private bool disposedValue;

        public BaseTest(MySqlDatabaseFixture databaseFixture, ITestOutputHelper testOutputHelper)
        {
            this.TestOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));

            var services = new ServiceCollection();
            services.RegisterServices();
            services.AddDbContext<SampleDbContext>(options =>
            {
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
                options.LogTo(this.TestOutputHelper.WriteLine, minimumLevel: LogLevel.Information);
                options.UseMySQL(databaseFixture.ConnectionString);
            });

            var serviceProviderOptions = new ServiceProviderOptions { ValidateScopes = true, ValidateOnBuild = true };
            this._rootServiceProvider = services.BuildServiceProvider(serviceProviderOptions);
            this._scope = this._rootServiceProvider.CreateScope();
        }

        protected ITestOutputHelper TestOutputHelper { get; }
        protected IGenreService GenreService => this._scope.ServiceProvider.GetRequiredService<IGenreService>();
        protected SampleDbContext DbContext => this._scope.ServiceProvider.GetRequiredService<SampleDbContext>();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.DbContext.Genres.ExecuteDelete();
                    this.DbContext.Songs.ExecuteDelete();
                    this.DbContext.Artists.ExecuteDelete();
                    this.DbContext.SaveChanges();

                    this._scope.Dispose();
                    this._rootServiceProvider.Dispose();
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
