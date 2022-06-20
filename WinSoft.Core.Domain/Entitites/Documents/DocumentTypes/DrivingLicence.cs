namespace WinSoft.Core.Domain.Entitites.Documents.DocumentTypes
{
    public class DrivingLicence : Document
    {
        public string FullName { get; set; }
        public string CarClass { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
