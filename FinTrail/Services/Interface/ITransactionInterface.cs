using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinTrail.Services.Interface
{
    public interface ITransactionInterface
    {
        bool AddTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
        List<Transaction> GetTransactionsByType(string type);
        decimal GetBalance();
        bool RemoveTransaction(Guid transactionId);
    }
}
