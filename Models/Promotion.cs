namespace HrAppApi.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string PromotionTitle { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string NewRole { get; set; }
        public decimal SalaryRevision { get; set; }
    }
}
