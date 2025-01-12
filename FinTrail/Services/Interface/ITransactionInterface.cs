using FinTrail.Model;

namespace FinTrail.Services.Interface
{
    public interface ITransactionInterface
    {
        // Saves a new transaction with the given details.
        // Returns true if the debt is successful, or false if the there is any error 
        bool AddTransaction(Transaction transactions);

        // Retrieves a list of all transactions.
        // Returns the complete collection of Transaction objects.
        List<Transaction> GetAllTransactions();
    }
}
