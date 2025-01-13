namespace FinTrail.Model
{
    public class User
    {
        /* variables for User login */
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string SelectedCurrency { get; set; }
        public string Salt { get; set; }
        public decimal Balance { get; set; } = 0;
    }
}
