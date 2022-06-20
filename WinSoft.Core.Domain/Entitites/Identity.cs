using System.ComponentModel.DataAnnotations;

namespace WinSoft.Core.Domain.Entitites
{
    public abstract class Identity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
