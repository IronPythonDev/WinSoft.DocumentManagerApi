using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Data.Configurations
{
    public class DrivingLicenceConfiguration : IEntityTypeConfiguration<DrivingLicence>
    {
        public void Configure(EntityTypeBuilder<DrivingLicence> builder)
        {
            builder.Property(p => p.Status).HasDefaultValue(DocumentStatus.Waiting);
        }
    }
}