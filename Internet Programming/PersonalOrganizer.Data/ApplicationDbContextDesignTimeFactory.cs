using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace PersonalOrganizer.Data;

public class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
        optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
        optionsBuilder.UseSqlServer();

        ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);
        return dbContext;
    }
}
