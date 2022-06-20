using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Data.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.Property(p => p.Status).HasDefaultValue(DocumentStatus.Waiting);
        }
    }
}