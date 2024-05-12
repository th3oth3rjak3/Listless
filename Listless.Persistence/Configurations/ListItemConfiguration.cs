using Listless.Persistence.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listless.Persistence.Configurations;
internal class ListItemConfiguration : IEntityTypeConfiguration<DbListItem>
{
    public void Configure(EntityTypeBuilder<DbListItem> builder)
    {
        builder
            .HasKey(item => item.Id);

        builder
            .Property(item => item.Description)
            .IsRequired()
            .HasMaxLength(300);

        builder
            .Property(item => item.IsStarted)
            .IsRequired();

        builder
            .Property(item => item.IsComplete)
            .IsRequired();

        builder
            .Property(item => item.StartBy)
            .IsRequired(false);

        builder
            .Property(item => item.DueBy)
            .IsRequired(false);

        builder.HasOne(item => item.UserList)
            .WithMany(list => list.Items)
            .HasForeignKey(item => item.UserListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
