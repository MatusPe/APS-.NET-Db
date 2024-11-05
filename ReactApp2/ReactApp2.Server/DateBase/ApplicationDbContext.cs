using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.Entity;

namespace ReactApp2.Server.DateBase;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<CashExpenses> CashExpenses { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Investment> Investments { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Expenses> Expenses { get; set; }
    
}