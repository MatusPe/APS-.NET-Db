using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface ICashExpenseRepositary
{
    Task<List<CashExpenses>> GetAllExpendsAsync();
    Task<CashExpenses?> GetExpendByIdAsync(int id);
    Task<CashExpenses> AddExpenseAsync(CashExpenses cashExpense);
    Task<CashExpenses> UpdateExpenseAsync(int id, CashExpenses cashExpense);
    Task<CashExpenses?> DeleteExpenseAsync(int id);
    Task<CashExpenses> GetExpenseByDateAsync(DateTime date);
    
}