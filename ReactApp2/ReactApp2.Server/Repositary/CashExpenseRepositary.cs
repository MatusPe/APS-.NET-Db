using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class CashExpenseRepositary: ICashExpenseRepositary
{
    private readonly ApplicationDbContext context;
    public CashExpenseRepositary(ApplicationDbContext context)
    {
        this.context=context;
    }

    public async Task<List<CashExpenses>> GetAllExpendsAsync()
    {
        return await context.CashExpenses.Include(c=>c.Products).ToListAsync();
        
    }

    public async Task<CashExpenses> GetExpendByIdAsync(int id)
    {
        var expense = await context.CashExpenses.Include(C => C.Products).FirstOrDefaultAsync(x => x.Id == id);
        if (expense == null)
        {
            return null;
        }
        return expense;
        
    }

    public async Task<CashExpenses> AddExpenseAsync(CashExpenses cashExpense)
    {
        
        
         await context.CashExpenses.AddAsync(cashExpense);
        await context.SaveChangesAsync();
        return cashExpense;
        
    }

    public async Task<CashExpenses> UpdateExpenseAsync(int id, CashExpenses cashExpense)
    {
        var expenseToUpdate = await context.CashExpenses.FindAsync(id);
        if (expenseToUpdate == null)
        {
            return null;
        }
        expenseToUpdate.Type=cashExpense.Type;
        expenseToUpdate.Company = cashExpense.Company;
        expenseToUpdate.Quantity = cashExpense.Quantity;
        expenseToUpdate.TotalPriceDPH = cashExpense.TotalPriceDPH;
        expenseToUpdate.TotalPriceNotDPH = cashExpense.TotalPriceNotDPH;
        expenseToUpdate.ExpendDate = cashExpense.ExpendDate;
        expenseToUpdate.Description = cashExpense.Description;
        return expenseToUpdate;
    }

    public async Task<CashExpenses> DeleteExpenseAsync(int id)
    {
        var expenseToDelete = await context.CashExpenses.FindAsync(id);
        if (expenseToDelete == null)
        {
            return null;
        }
        context.CashExpenses.Remove(expenseToDelete);
        await context.SaveChangesAsync();
        return expenseToDelete;
        
    }

    public Task<CashExpenses> GetExpenseByDateAsync(DateTime date)
    {
        throw new NotImplementedException();
    }
}