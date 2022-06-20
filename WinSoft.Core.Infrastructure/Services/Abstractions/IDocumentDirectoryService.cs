using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Domain.Entitites.Documents;

namespace WinSoft.Core.Infrastructure.Services.Abstractions
{
    public interface IDocumentDirectoryService
    {
        Task<DocumentDirectory> CreateDocumentDirectory();
        Task<DocumentDirectory> GetAdministratorDocumentDirectory(Guid directoryId, Guid administratorId);
        Task<DocumentDirectory> GetDocumentDirectoryById(Guid directoryId);
        Task<IList<DocumentDirectory>> GetAdministratorDocumentDirectories(Guid administratorId);
        Task ChangeDocumentDirectoryAdministrator(User user, DocumentDirectory directory);
    }
}
