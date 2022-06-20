using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Data.Configurations
{
    public class DocumentsPackageConfiguration : IEntityTypeConfiguration<DocumentsPackage>
    {
        public void Configure(EntityTypeBuilder<DocumentsPackage> builder)
        {
            builder.HasOne(p => p.Owner).WithMany(p => p.DocumentsPackages).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Directory).WithMany(p => p.DocumentsPackages);
            builder.Property(p => p.Status).HasDefaultValue(DocumentStatus.Waiting);
        }
    }
}