using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Domain.Entitites.Documents;

namespace WinSoft.Core.Infrastructure.Services.Abstractions
{
    public interface IDocumentPackageService
    {
        Task<DocumentsPackage> CreatePackage(DocumentsPackage package);
        Task<DocumentsPackage> GetPackageById(Guid id);
        Task<DocumentsPackage> GetUserPackageById(Guid userId, Guid packageId);
        Task<bool> CanVerifyPackage(Guid packageId);
        Task FullUpdatePackage(DocumentsPackage documentsPackage);
    }
}
