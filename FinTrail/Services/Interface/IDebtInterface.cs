using FinTrail.Model;

namespace FinTrail.Services.Interface
{
    public interface IDebtInterface
    {
        // Returns true if the debt is successful, or false if the there is any error 
        bool AddDebt(Debt debts);

        // Returns the complete collection of Debts.
        List<Debt> GetAllDebts();


        // Method to update dept information
        void UpdateDebt(List<Debt> debts);
    }
}
