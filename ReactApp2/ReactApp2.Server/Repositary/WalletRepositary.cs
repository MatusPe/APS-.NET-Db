using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class WalletRepositary:IWalletRepositary
{
    public readonly ApplicationDbContext _context;

    public WalletRepositary(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    
    public async Task<List<Wallet>> GetAllWalletAsync()
    {
        var Wallets=await _context.Wallets.ToListAsync();
        return Wallets;
        
    }

    public async Task<Wallet?> GetWalletByIdAsync(int id)
    {
        var wallet = await _context.Wallets.FirstOrDefaultAsync(x => x.Id == id);
        if (wallet == null)
        {
            return null;
        }
        return wallet;
    }
    
    public async Task<Wallet> AddWalletAsync(Wallet wallet)
    {
        await _context.AddAsync(wallet);
        await _context.SaveChangesAsync();
        return wallet;
        
    }

    public async Task<Wallet> UpdateWalletAsync(int id, Wallet wallet)
    {
        var oldWallet = await _context.Wallets.FindAsync(id);
        if (oldWallet == null)
        {
            return null;
        }
        oldWallet.Name = wallet.Name;
        return oldWallet;
    }

    public async Task<Wallet> DeleteWalletAsync(int id)
    {
        var relatedBudgets = _context.Budgets.Where(b => b.Id == id);
        _context.Budgets.RemoveRange(relatedBudgets);
        var wallet = await _context.Wallets.FindAsync(id);
        _context.Wallets.Remove(wallet);
        _context.SaveChanges();
        return wallet;
    }

    public Task<Wallet> GetWalletbyNameAsync(string Name)
    {
        throw new NotImplementedException();
    }
}