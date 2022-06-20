using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinSoft.Core.Domain.Entitites.Documents;

namespace WinSoft.Core.Data.Configurations
{
    public class DocumentDirectoryConfiguration : IEntityTypeConfiguration<DocumentDirectory>
    {
        public void Configure(EntityTypeBuilder<DocumentDirectory> builder)
        {
            builder.HasOne(p => p.Administrator).WithMany(p => p.OwnedDocumentDirectory).OnDelete(DeleteBehavior.SetNull);
        }
    }
}