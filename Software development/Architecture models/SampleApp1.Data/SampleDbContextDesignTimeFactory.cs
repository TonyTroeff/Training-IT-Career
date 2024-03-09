using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace SampleApp1.Data
{
    public class SampleDbContextDesignTimeFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args)
        {
            if (args.Length != 1) throw new InvalidOperationException("You need to pass the connection string to use as the only argument.");
            string connectionString = args[0];

            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();

            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseMySQL(connectionString);

            SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}
