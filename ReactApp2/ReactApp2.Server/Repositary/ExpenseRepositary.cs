using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class ExpenseRepositary:IExpensesRepositary
{

    private readonly ApplicationDbContext _context;
    public ExpenseRepositary(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public async Task<List<Expenses>> GetAllExpensesAsync()
    {
        return await _context.Expenses.Include(c=>c.CashExpenses).Include(c=>c.Transactions).ToListAsync();
    }

    public Task<Expenses> UpdateExpensesAsync(Expenses expenses)
    {
        throw new NotImplementedException();
    }


    public async Task<Expenses> DeleteExpensesAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        
        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return expense;
        
    }

    public async Task<Expenses> AddExpensesAsync(Expenses expenses)
    {
        await _context.Expenses.AddAsync(expenses);
        await _context.SaveChangesAsync();
        return expenses;
    }

    public async Task<Expenses> GetExpensesByIdAsync(int id)
    {
        var expenses = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if (expenses == null)
        {
            return null;
        }
        return expenses;
    }
}