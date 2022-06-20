namespace WinSoft.Core.Presentation.DTO.Documents
{
    public class CreditCardDTO : Document
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
