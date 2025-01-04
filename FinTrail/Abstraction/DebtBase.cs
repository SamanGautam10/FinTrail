using FinTrail.Model;
using System.Text.Json;

namespace FinTrail.Abstraction
{
    public abstract class DebtBase
    {
        // File path where the debts.json file is stored in the app's local data directory
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "debts.json");

        // Method to load debt data from the debts.json file
        protected List<Debt> LoadDebts()
        {
            // If the file does not exist, return an empty list to indicate no users are saved
            if (!File.Exists(FilePath)) return new List<Debt>();

            // Read the JSON content from the file
            var json = File.ReadAllText(FilePath);

            // Deserialize the JSON content into a list of User objects
            // If deserialization fails (null result), return an empty list
            return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
        }

        // Method to save user data to the users.json file
        protected void SaveDebt(List<Debt> debts)
        {
            // Serialize the list of Debt objects into a JSON string
            var json = JsonSerializer.Serialize(debts);

            // Write the JSON string to the users.json file
            File.WriteAllText(FilePath, json);
        }
    }
}
