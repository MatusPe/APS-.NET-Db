using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface IWalletRepositary
{
    Task<List<Wallet>> GetAllWalletAsync();
    Task<Wallet?> GetWalletByIdAsync(int id);
    Task<Wallet> AddWalletAsync(Wallet wallet);
    Task<Wallet> UpdateWalletAsync(int id, Wallet wallet);
    Task<Wallet?> DeleteWalletAsync(int id);
    Task<Wallet> GetWalletbyNameAsync(String Name);
}