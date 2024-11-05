using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface IExpensesRepositary
{
    Task<List<Expenses>> GetAllExpensesAsync();
    Task<Expenses> UpdateExpensesAsync(Expenses expenses);
    Task<Expenses> DeleteExpensesAsync(int id);
    Task<Expenses> AddExpensesAsync(Expenses expenses);
    Task<Expenses> GetExpensesByIdAsync(int id);

}