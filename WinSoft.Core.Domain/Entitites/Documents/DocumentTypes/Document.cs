using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Domain.Entitites.Documents.DocumentTypes
{
    public abstract class Document : Identity
    {
        public DocumentStatus Status { get; set; }
         
        public DocumentsPackage? Package { get; set; }
    }
}
