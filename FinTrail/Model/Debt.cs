namespace FinTrail.Model
{
    // Class for Debt informations
    public class Debt
    {
        //variables for debt info
        public int DebtID { get; set; }
        public required string DebtFrom { get; set; }
        public required decimal Amount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Relationship { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
