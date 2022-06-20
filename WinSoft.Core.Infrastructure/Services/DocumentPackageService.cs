using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSoft.Core.Data;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.Core.Infrastructure.Services
{
    public class DocumentPackageService : IDocumentPackageService
    {
        public DocumentPackageService(ApplicationContext applicationContext)
        {
            ApplicationContext=applicationContext;
        }

        public ApplicationContext ApplicationContext { get; }

        public async Task FullUpdatePackage(DocumentsPackage documentsPackage)
        {
            ApplicationContext.DocumentsPackages.Update(documentsPackage);
            await ApplicationContext.SaveChangesAsync();
        }

        public async Task<bool> CanVerifyPackage(Guid packageId)
        {
            var package = await GetPackageById(packageId);

            return 
                package.Passport?.Status == Domain.Entitites.Enums.DocumentStatus.Verified && 
                package.CreditCard?.Status == Domain.Entitites.Enums.DocumentStatus.Verified && 
                package.DrivingLicence?.Status == Domain.Entitites.Enums.DocumentStatus.Verified;
        }
        public async Task<DocumentsPackage> GetPackageById(Guid id)
        {
            try
            {
                return await ApplicationContext.DocumentsPackages
                    .Include(p => p.Passport)
                    .Include(p => p.CreditCard)
                    .Include(p => p.DrivingLicence)
                    .FirstAsync(p => p.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("Package not found!");
            }
        }
        public async Task<DocumentsPackage> GetUserPackageById(Guid userId, Guid packageId)
        {
            try
            {
                return await ApplicationContext.DocumentsPackages
                    .Include(p => p.Passport)
                    .Include(p => p.CreditCard)
                    .Include(p => p.DrivingLicence)
                    .FirstAsync(p => p.Id == packageId && p.OwnerId == userId);
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("Package not found!");
            }
        }

        public async Task<DocumentsPackage> CreatePackage(DocumentsPackage package)
        {
            package = (await ApplicationContext.DocumentsPackages.AddAsync(package)).Entity;

            await ApplicationContext.SaveChangesAsync();

            return package;
        }
    }
}
