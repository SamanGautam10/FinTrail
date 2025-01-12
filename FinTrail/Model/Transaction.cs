namespace FinTrail.Model
{
    // Class for Transactions Information
    public class Transaction
    {
        public int TransactionID { get; set; }
        public required string TransactionName { get; set; }
        public required decimal Amount { get; set; }
        public required string Category { get; set; } // Debit or Credit
        public DateOnly TransactionDate { get; set; }
        public string Notes { get; set; }
        public string Tags { get; set; }
    }

    // Class for managing Balance Information
    public class Balance
    {
        public decimal Amount { get; set; }
    }
}
