using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class Expenses
{
    [Key]
    public int Id { get; set; }
    
    public List<CashExpenses> CashExpenses { get; set; }
    public List<Transaction> Transactions { get; set; }
    public int WalletId { get; set; }
}