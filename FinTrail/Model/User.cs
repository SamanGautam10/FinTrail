using FinTrail.Base;

namespace FinTrail.Model
{
    public class User
    {
        /* variables for User login */
        public Guid UserID { get; set; }  /* Unique ID for the user */
        public required string Username { get; set; } 
        public required string Password { get; set; }

        public string SelectedCurrency { get; set; }
    }
}
