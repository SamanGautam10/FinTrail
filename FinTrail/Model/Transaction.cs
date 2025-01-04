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
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Tags { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Debit" or "Credit"
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
