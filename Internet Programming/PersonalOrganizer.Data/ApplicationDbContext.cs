using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Data.Configurations;
using PersonalOrganizer.Data.Models;

namespace PersonalOrganizer.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<TaskGroup> TaskGroups { get; set; }
    public DbSet<Label> Labels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new TaskItemConfiguration());
        builder.ApplyConfiguration(new TaskGroupConfiguration());
        builder.ApplyConfiguration(new LabelConfiguration());
    }
}
