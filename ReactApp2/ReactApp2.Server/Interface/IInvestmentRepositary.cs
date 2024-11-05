using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface IInvestmentRepositary
{
    Task<List<Investment>> GetAllInvestmentAsync();
    Task<Investment?> GetInvestmentByIdAsync(int id);
    Task<Investment> AddInvestmentAsync(Investment investment);
    Task<Investment> UpdateInvestmentAsync(int id, Investment investment);
    Task<Investment?> DeleteInvestmentAsync(int id);
    Task<Investment> GetInvestmentbyNameAsync(String Name);
}