namespace HrAppApi.Models
{
    public class AppraisalCycle
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Period { get; set; }
        public int AppraisalScore { get; set; }
        public string Status { get; set; }
    }
}
