using WinSoft.Core.Domain.Entitites.Enums;
using WinSoft.Core.Presentation.DTO.Abstraction;

namespace WinSoft.Core.Presentation.DTO.Documents
{
    public class DocumentsPackageSmallDTO : Identity
    {
        public Guid OwnerId { get; set; }
        public Guid DirectoryId { get; set; }

        public Guid PassportId { get; set; }
        public Guid DrivingLicenceId { get; set; }
        public Guid CreditCardId { get; set; }

        public DocumentStatus Status { get; set; }
    }
}
