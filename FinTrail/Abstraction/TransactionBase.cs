using System.Text.Json;
using FinTrail.Model;

namespace FinTrail.Abstraction
{
    public abstract class TransactionBase
    {
        // File path where the transaction.json file is stored in the app's local data directory
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "transaction.json");

        // Method to load transaction data from the transaction.json file
        protected List<Transaction> LoadTransactions()
        {
            // If the file does not exist, return an empty list to indicate no users are saved
            if (!File.Exists(FilePath)) return new List<Transaction>();

            // Read the JSON content from the file
            var json = File.ReadAllText(FilePath);

            // Deserialize the JSON content into a list of Transaction objects
            // If deserialization fails (null result), return an empty list
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        // Method to save user data to the users.json file
        protected void SaveDebt(List<Transaction> transactions)
        {
            // Serialize the list of Debt objects into a JSON string
            var json = JsonSerializer.Serialize(transactions);

            // Write the JSON string to the users.json file
            File.WriteAllText(FilePath, json);
        }
    }
}
