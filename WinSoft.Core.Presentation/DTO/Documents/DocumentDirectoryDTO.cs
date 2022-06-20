using WinSoft.Core.Presentation.DTO.Abstraction;

namespace WinSoft.Core.Presentation.DTO.Documents
{

    public class DocumentDirectoryDTO : Identity
    {
        public IList<DocumentsPackageSmallDTO> DocumentsPackages { get; set; } = new List<DocumentsPackageSmallDTO>();
    }
}
