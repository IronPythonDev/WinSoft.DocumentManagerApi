namespace WinSoft.Core.Domain.Entitites.Documents
{
    public class DocumentDirectory : Identity
    {
        public Guid AdministratorId { get; set; }

        public User? Administrator { get; set; }

        public IList<DocumentsPackage> DocumentsPackages { get; set; } = new List<DocumentsPackage>();
    }
}
