using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class InvestmentRepositary:IInvestmentRepositary
{

    public readonly ApplicationDbContext _context;
    public InvestmentRepositary(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public async Task<List<Investment>> GetAllInvestmentAsync()
    {
        return await _context.Investments.ToListAsync();
    }

    public async Task<Investment?> GetInvestmentByIdAsync(int id)
    {
        var investment=await _context.Investments.FindAsync(id);
        if (investment == null)
        {
            return null;
        }
        return investment;
    }

    public async Task<Investment> AddInvestmentAsync(Investment investment)
    {
        await _context.Investments.AddAsync(investment);
        _context.SaveChanges();
        return investment;
    }

    public async Task<Investment> UpdateInvestmentAsync(int id, Investment investment)
    {
        var oldInvestment=await _context.Investments.FindAsync(id);
        if (oldInvestment == null)
        {
            return null;
        }
        oldInvestment.InvestType = investment.InvestType;
        oldInvestment.InvestmentStock = investment.InvestmentStock;
        oldInvestment.InvestmentAmount = investment.InvestmentAmount;
        oldInvestment.InvestmentProfit = investment.InvestmentProfit;
        oldInvestment.Duration = investment.Duration;
        oldInvestment.InvestmentDate = investment.InvestmentDate;
        oldInvestment.investmentDescription = investment.investmentDescription;
        
        return oldInvestment;
    }

    public async Task<Investment?> DeleteInvestmentAsync(int id)
    {
        var investment=await _context.Investments.FindAsync(id);
        if (investment == null)
        {
            return null;
        }
        _context.Investments.Remove(investment);
        await _context.SaveChangesAsync();
        return investment;
        
    }

    public Task<Investment> GetInvestmentbyNameAsync(string Name)
    {
        throw new NotImplementedException();
    }
}