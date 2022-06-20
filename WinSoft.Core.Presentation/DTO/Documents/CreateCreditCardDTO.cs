namespace WinSoft.Core.Presentation.DTO.Documents
{
    public class CreateCreditCardDTO 
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
