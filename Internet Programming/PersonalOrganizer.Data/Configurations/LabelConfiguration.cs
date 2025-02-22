using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalOrganizer.Data.Configurations.Extensions;
using PersonalOrganizer.Data.Models;

namespace PersonalOrganizer.Data.Configurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureUserResource();

        builder.Property(l => l.Name)
            .HasMaxLength(1024)
            .IsUnicode()
            .IsRequired();

         builder.HasIndex(l => new { l.UserId, l.Name }).IsUnique();
    }
}
