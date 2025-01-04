using FinTrail.Abstraction;
using FinTrail.Model;
using FinTrail.Services.Interface;

namespace FinTrail.Services
{
    public class UserService : UserBase, IUserInterface
    {
        private List<User> _users;
        private User? _loggedInUser; // Track the currently logged-in user


        // Default admin username and password for initial seeding.
        public const string SeedUsername = "admin";
        public const string SeedPassword = "password";

        public UserService()
        {
            _users = LoadUsers();

            // Ensure there's an admin user if no users exist.
            if (!_users.Any())
            {
                _users.Add(new User { Username = SeedUsername, Password = SeedPassword});
                SaveUsers(_users);
            }
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        // Modified Login method to check against users.json
        public bool Login(User user)
        {
            // Validate input for null or empty values
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false; // Invalid input
            }

            // Check if the username and password match any user in the list (loaded from users.json)
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                _loggedInUser = existingUser; // Set the logged-in user

                // Login successful then update the currency field
                existingUser.SelectedCurrency = user.SelectedCurrency;

                // Save the updated users list back to the JSON file
                SaveUsers(_users);

                return true;
            }

            return false; // Login failed: invalid username or password
        }

        // Register method remains the same
        public bool Register(User user)
        {
            //checking if username already exists
            if (_users.Any(u => u.Username == user.Username)) return false;

            // Set a new Guid for the UserID
            user.UserID = Guid.NewGuid();

            _users.Add(new User 
            { 
                UserID = user.UserID,
                Username = user.Username, 
                Password = user.Password});
            SaveUsers(_users);
            return true;
        }

        public void Logout()
        {
            _loggedInUser = null; // Clear the logged-in user
        }
    }
}
