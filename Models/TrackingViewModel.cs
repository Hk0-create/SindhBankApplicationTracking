namespace SindhBankApplicationTracking.Models
{
    public enum ApplicationStatus
    {
        InProcess,
        Rejected,
        Approved
    }

    public class TrackingViewModel
    {
        public string? TrackingId { get; set; }
        public bool HasSearched { get; set; }
        public bool IsFound { get; set; }
        public ApplicationStatus? Status { get; set; }
    }
}