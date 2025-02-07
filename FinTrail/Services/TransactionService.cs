﻿using FinTrail.Abstraction;
using FinTrail.Model;
using FinTrail.Services.Interface;

namespace FinTrail.Services
{
    public class TransactionService : TransactionBase, ITransactionInterface
    {
        public List<Transaction> _transactions;

        public TransactionService()
        {
            _transactions = LoadTransactions();

            // Ensure there's at least one debt object for initial seeding
            if (!_transactions.Any())
            {
                _transactions.Add(new Transaction
                {
                    TransactionName = "Saman Gautam",
                    Amount = 0m,
                    Category = "Debit",
                    TransactionDate = new DateTime(2025, 12, 21),
                    Notes = "Family",
                    Tags = "Grocery"
                });

                SaveDebt(_transactions);
            }
        }

        // Method to add transaction in json file
        public bool AddTransaction(Transaction transactions)
        {
            if (transactions == null)
            {
                return false; // Invalid transaction object
            }

            // Generate TransactionID by finding the maximum TransactionID and incrementing it
            int newTransactionID = _transactions.Any() ? _transactions.Max(d => d.TransactionID) + 1 : 1;
            transactions.TransactionID = newTransactionID; // Assign the generated TransactionID

            _transactions.Add(transactions); // Add the transaction object to the list
            SaveDebt(_transactions);  // Save the transaction to file

            return true; // Indicate success
        }


        // Method to get all transactions from json file
        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }
    }
}
