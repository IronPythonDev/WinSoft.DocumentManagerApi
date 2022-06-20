using System.ComponentModel.DataAnnotations;

namespace WinSoft.Core.Domain.Entitites.Documents.DocumentTypes
{
    public class CreditCard : Document
    {
        [Required, MaxLength(20), MinLength(16)]
        public string CardNumber { get; set; }

        [Required, MaxLength(99), MinLength(1)]
        public string OwnerName { get; set; }

        public DateTime ExpiredAt { get; set; }
    }
}
