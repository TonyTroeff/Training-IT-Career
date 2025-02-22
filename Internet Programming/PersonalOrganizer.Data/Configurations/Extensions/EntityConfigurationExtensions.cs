using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Data.Configurations.Extensions;

internal static class EntityConfigurationExtensions
{
    internal static void ConfigureEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IEntity
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.LastModifiedAt)
            .IsRequired();

        builder.Property(e => e.IsDeleted)
            .IsRequired();

        builder.HasQueryFilter(e => !e.IsDeleted);
    }

    internal static void ConfigureUserResource<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IUserResource
    {
        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
