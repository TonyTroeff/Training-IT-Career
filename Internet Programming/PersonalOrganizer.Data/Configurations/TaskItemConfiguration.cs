using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalOrganizer.Data.Configurations.Extensions;
using PersonalOrganizer.Data.Models;

namespace PersonalOrganizer.Data.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureUserResource();

        builder.Property(ti => ti.Title)
            .HasMaxLength(1024)
            .IsUnicode()
            .IsRequired();

        builder.Property(ti => ti.Description)
            .HasMaxLength(-1)
            .IsUnicode()
            .IsRequired();

        builder.Property(ti => ti.DueDate)
            .IsRequired(false);

        builder.HasOne(ti => ti.Group)
            .WithMany(tg => tg.Tasks)
            .HasForeignKey(ti => ti.GroupId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(ti => ti.Labels)
            .WithMany(l => l.Tasks);
    }
}
