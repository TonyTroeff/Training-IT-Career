using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalOrganizer.Data.Configurations.Extensions;
using PersonalOrganizer.Data.Models;

namespace PersonalOrganizer.Data.Configurations;

public class TaskGroupConfiguration : IEntityTypeConfiguration<TaskGroup>
{
    public void Configure(EntityTypeBuilder<TaskGroup> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureUserResource();

        builder.Property(tg => tg.Name)
            .HasMaxLength(1024)
            .IsUnicode()
            .IsRequired();

        builder.Property(tg => tg.Description)
            .HasMaxLength(-1)
            .IsUnicode()
            .IsRequired();

        builder.HasIndex(tg => new { tg.UserId, tg.Name }).IsUnique();
    }
}
