using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrail.Model
{
    public class Transaction
    {
        // Initializing variables required for transaction
        public int TransactionId { get; set; }
        public string Notes { get; set; } // Name field corrected to Description
        public decimal Amount { get; set; }
        public string Category { get; set; } // Credit or Debit
        public required DateTime Date { get; set; }
        public required string Tags { get; set; } // Category for Cash Inflow/Outflow
    }
}
