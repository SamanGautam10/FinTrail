﻿using FinTrail.Abstraction;
using FinTrail.Model;
using FinTrail.Services.Interface;


namespace FinTrail.Services
{
    public class DebtService : DebtBase, IDebtInterface
    {
        public List<Debt> _debts;

        public DebtService()
        {
            _debts = LoadDebts();

            // Ensure there's at least one debt object for initial seeding
            if (!_debts.Any())
            {
                _debts.Add(new Debt
                {
                    DebtFrom = "Saman Gautam",
                    Amount = 0m,
                    StartDate = new DateTime(2024, 12, 24),
                    EndDate = new DateTime(2025, 12, 21),
                    Relationship = "Family",
                    Description = "Debt Taken to buy new water bottle",
                    Status = "Pending"
                });

                SaveDebt(_debts);
            }
        }

        public bool AddDebt(Debt debt)
        {
            if (debt == null)
            {
                return false; // Invalid debt object
            }

            // Generate DebtID by finding the maximum DebtID and incrementing it
            int newDebtID = _debts.Any() ? _debts.Max(d => d.DebtID) + 1 : 1;
            debt.DebtID = newDebtID; // Assign the generated DebtID

            _debts.Add(debt); // Add the debt object to the list
            SaveDebt(_debts);  // Save the debts to file

            return true; // Indicate success
        }

        public List<Debt> GetAllDebts()
        {
            return _debts; // Return the in-memory list of debts
        }

        public void UpdateDebt(List<Debt> debts)
        {
            SaveDebt(debts); // Save updated list of debts to the JSON file
        }
    }
}
