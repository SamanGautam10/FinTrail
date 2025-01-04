using FinTrail.Abstraction;
using FinTrail.Model;
using FinTrail.Services.Interface;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            // Find the existing user by username
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username);

            if (existingUser == null)
            {
                return false; // No such user found
            }

            // Convert the stored salt from Base64 to byte array
            byte[] salt = Convert.FromBase64String(existingUser.Salt);

            // Hash the entered password with the stored salt using PBKDF2
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Compare the hashed password with the stored hash
            if (hashedPassword == existingUser.Password)
            {
                _loggedInUser = existingUser; // Set the logged-in user

                // Update the currency field (if necessary)
                existingUser.SelectedCurrency = user.SelectedCurrency;

                // Save the updated user list back to the JSON file
                SaveUsers(_users);

                return true; // Login successful
            }

            return false; // Login failed: invalid username or password
        }

        // Register method remains the same
        public bool Register(User user)
        {
            // Generate a salt for the password
            byte[] salt = new byte[128 / 8]; // 128-bit salt
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); // Generate random bytes for the salt
            }

            // Hash the password with the salt using PBKDF2
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000, // Perform 10,000 iterations
                numBytesRequested: 256 / 8)); // Request 256 bits (32 bytes) hash

            // Save user with the hashed password and salt
            user.Password = hashedPassword;
            user.Salt = Convert.ToBase64String(salt); // Save the salt as well for verification later

            // Save user to the in-memory list
            _users.Add(user);
            SaveUsers(_users);
            return true;
        }

        public void Logout()
        {
            _loggedInUser = null; // Clear the logged-in user
        }
    }
}
