using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Role).IsRequired().HasDefaultValue(UserRole.User);
            builder.HasIndex(p => p.Role).IsUnique();
        }
    }
}