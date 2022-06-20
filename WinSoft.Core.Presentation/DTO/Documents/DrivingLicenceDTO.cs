namespace WinSoft.Core.Presentation.DTO.Documents
{
    public class DrivingLicenceDTO : Document
    {
        public string FullName { get; set; }
        public string CarClass { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
