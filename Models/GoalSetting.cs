namespace HrAppApi.Models
{
    public class GoalSetting
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string GoalTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
