using Listless.Persistence.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listless.Persistence.Configurations;
internal class UserListConfiguration : IEntityTypeConfiguration<DbUserList>
{
    public void Configure(EntityTypeBuilder<DbUserList> builder)
    {
        builder
            .HasKey(list => list.Id);

        builder
            .Property(list => list.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(list => list.Items)
            .WithOne(item => item.UserList)
            .HasForeignKey(item => item.UserListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
