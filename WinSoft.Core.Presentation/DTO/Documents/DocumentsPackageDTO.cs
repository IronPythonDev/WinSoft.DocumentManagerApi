using WinSoft.Core.Presentation.DTO.Abstraction;

namespace WinSoft.Core.Presentation.DTO.Documents
{

    public class DocumentsPackageDTO : Identity
    {
        public string? Status { get; set; }
        public Guid DirectoryId { get; set; }
        public Guid OwnerId { get; set; }

        public PassportDTO? Passport { get; set; }
        public DrivingLicenceDTO? DrivingLicence { get; set; }
        public CreditCardDTO? CreditCard { get; set; }
    }

    public class CreateDocumentsPackageDTO : Identity
    {
        public Guid DirectoryId { get; set; }

        public CreatePassportDTO? Passport { get; set; }
        public CreateDrivingLicenceDTO? DrivingLicence { get; set; }
        public CreateCreditCardDTO? CreditCard { get; set; }
    }
}
