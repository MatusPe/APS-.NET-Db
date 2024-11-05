using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface ILoanRepositary
{
    Task<List<Loan>> GetAllLoanAsync();
    Task<Loan?> GetLoanByIdAsync(int id);
    Task<Loan> AddLoanAsync(Loan loan);
    Task<Loan> UpdateLoanAsync(int id, Loan loan);
    Task<Loan?> DeleteLoanAsync(int id);
    Task<Loan> GetLoanbyNameAsync(String Name);
}