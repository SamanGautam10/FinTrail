namespace FinTrail.Model
{
    public class Debt
    {
        public int DebtID { get; set; }
        public required string DebtFrom { get; set; }
        public required decimal Amount { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Relationship { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
