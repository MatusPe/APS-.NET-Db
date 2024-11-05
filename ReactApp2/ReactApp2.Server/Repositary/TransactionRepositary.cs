using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class TransactionRepositary:ITransactionRepositary
{
    private readonly ApplicationDbContext _context;

    public TransactionRepositary(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Transaction>> GetAllTransactionAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction?> GetTransactionByIdAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return null;
        }
        return transaction;
    }

    public async Task<Transaction> AddTransactionAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> UpdateTransactionAsync(int id, Transaction transaction)
    {
        var oldTransaction = await _context.Transactions.FindAsync(id);
        if (oldTransaction == null)
        {
            return null;
        }
        oldTransaction.Transactiontype=transaction.Transactiontype;
        oldTransaction.TransactionName=transaction.TransactionName;
        oldTransaction.Sender=transaction.Sender;
        oldTransaction.Receiver=transaction.Receiver;
        oldTransaction.Amount=transaction.Amount;
        oldTransaction.Category=transaction.Category;
        oldTransaction.Date=transaction.Date;
        oldTransaction.Description=transaction.Description;
        await _context.SaveChangesAsync();
        return oldTransaction;
        
    }

    public async Task<Transaction?> DeleteTransactionAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return null;
        }
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public Task<Transaction> GetTransactionByDateAsync(DateTime date)
    {
        throw new NotImplementedException();
    }
}