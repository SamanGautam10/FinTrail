using FinTrail.Model;

namespace FinTrail.Services.Interface
{
    public interface IDebtInterface
    {
        // Saves a new debt with the given details.
        // Returns true if the debt is successful, or false if the there is any error 
        bool AddDebt(Debt debts);

        // Retrieves a list of all debts.
        // Returns the complete collection of Debts.
        List<Debt> GetAllDebts();
    }
}
