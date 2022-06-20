using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Domain.Entitites.Documents
{
    public class DocumentsPackage : Identity
    {
        public Guid OwnerId { get; set; }
        public Guid DirectoryId { get; set; }

        public Guid PassportId { get; set; }
        public Guid DrivingLicenceId { get; set; }
        public Guid CreditCardId { get; set; }

        public DocumentStatus Status { get; set; }

        public User Owner { get; set; }
        public DocumentDirectory Directory { get; set; }

        public Passport? Passport { get; set; }
        public DrivingLicence? DrivingLicence { get; set; }
        public CreditCard? CreditCard { get; set; }
    }
}
