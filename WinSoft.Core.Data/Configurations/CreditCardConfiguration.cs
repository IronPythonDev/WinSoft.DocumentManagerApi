using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Data.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.Property(p => p.Status).HasDefaultValue(DocumentStatus.Waiting);
        }
    }
}