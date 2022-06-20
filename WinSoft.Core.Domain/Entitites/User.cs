using System.ComponentModel.DataAnnotations;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Domain.Entitites.Enums;

namespace WinSoft.Core.Domain.Entitites
{

    public class User : Identity
    {
        [MaxLength(50)] public string Email { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.User;

        public IList<DocumentsPackage> DocumentsPackages { get; set; } = new List<DocumentsPackage>();
        public IList<DocumentDirectory> OwnedDocumentDirectory { get; set; } = new List<DocumentDirectory>();
    }
}
