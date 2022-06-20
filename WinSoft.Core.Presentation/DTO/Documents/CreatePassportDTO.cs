namespace WinSoft.Core.Presentation.DTO.Documents
{
    public class CreatePassportDTO
    {
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DateOfIssue { get; set; }
        public ulong Series { get; set; }
        public ulong RecordNumber { get; set; }
        public ulong Authority { get; set; }
    }
}
