namespace HrAppApi.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Reviewer { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
    }
}
