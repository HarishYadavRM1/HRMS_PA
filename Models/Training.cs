namespace HrAppApi.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string TrainingTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string CompletionStatus { get; set; }
    }
}
