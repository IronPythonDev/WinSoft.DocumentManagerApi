using Microsoft.EntityFrameworkCore;
using WinSoft.Core.Data;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.Core.Infrastructure.Services
{
    public class DocumentDirectoryService : IDocumentDirectoryService
    {
        public DocumentDirectoryService(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public ApplicationContext ApplicationContext { get; }

        public async Task ChangeDocumentDirectoryAdministrator(User user, DocumentDirectory directory)
        {
            directory.Administrator = user;

            ApplicationContext.DocumentDirectories.Update(directory);

            await ApplicationContext.SaveChangesAsync();
        }

        public async Task<DocumentDirectory> CreateDocumentDirectory()
        {
            var directory = await ApplicationContext.DocumentDirectories.AddAsync(new DocumentDirectory { });

            await ApplicationContext.SaveChangesAsync();

            return directory.Entity;
        }

        public async Task<IList<DocumentDirectory>> GetAdministratorDocumentDirectories(Guid administratorId)
        {
            return await ApplicationContext.DocumentDirectories.Include(p => p.DocumentsPackages).Where(p => p.AdministratorId == administratorId).ToListAsync();
        }

        public async Task<DocumentDirectory> GetAdministratorDocumentDirectory(Guid directoryId, Guid administratorId)
        {
            try
            {
                return await ApplicationContext.DocumentDirectories.Include(p => p.DocumentsPackages).FirstAsync(p => p.Id == directoryId && p.AdministratorId == administratorId);
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("Directory not found!");
            }
        }

        public async Task<DocumentDirectory> GetDocumentDirectoryById(Guid directoryId)
        {
            try
            {
                return await ApplicationContext.DocumentDirectories.Include(p => p.DocumentsPackages).FirstAsync(p => p.Id == directoryId);
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("Directory not found!");
            }
        }
    }
}
