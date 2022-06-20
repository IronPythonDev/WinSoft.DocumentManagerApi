using System.ComponentModel.DataAnnotations;

namespace WinSoft.Core.Domain.Entitites.Documents.DocumentTypes
{
    public class Passport : Document
    {
        [MaxLength(99), MinLength(3)] public string FullName { get; set; }
        [Required] public DateTime Birthdate { get; set; }
        [Required] public DateTime DateOfIssue { get; set; }
        [Required] public ulong Series { get; set; }
        [Required] public ulong RecordNumber { get; set; }
        [Required] public ulong Authority { get; set; }
    }
}
