using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface ITransactionRepositary
{
    Task<List<Transaction>> GetAllTransactionAsync();
    Task<Transaction?> GetTransactionByIdAsync(int id);
    Task<Transaction> AddTransactionAsync(Transaction transaction);
    Task<Transaction> UpdateTransactionAsync(int id, Transaction transaction);
    Task<Transaction?> DeleteTransactionAsync(int id);
    Task<Transaction> GetTransactionByDateAsync(DateTime date);
}