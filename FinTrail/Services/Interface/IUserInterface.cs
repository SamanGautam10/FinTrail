using FinTrail.Model;

namespace FinTrail.Services.Interface
{
    public interface IUserInterface
    {
        // Authenticates a user based on their username and password.
        // Returns true if the credentials are valid, otherwise false.
        bool Login(User user);

        // Registers a new user with the given details.
        // Returns true if the registration is successful, or false if the username already exists.
        bool Register(User user);

        // Retrieves a list of all registered users.
        // Returns the complete collection of User objects.
        List<User> GetAllUsers();

        //function to perform logout
        void Logout();

        // Retrives detail of logged in user
        User? GetLoggedInUser();

        // Function to update balance
        void UpdateBalance(string username, decimal transactionAmount, string category);

        // Getting balance of the user
        User GetBalance();
    }
}
