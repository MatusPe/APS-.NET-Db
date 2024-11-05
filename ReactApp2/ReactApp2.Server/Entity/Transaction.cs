using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class Transaction
{
    [Key]
    public int Id { get; set; }
    public String Transactiontype { get; set; }
    public String TransactionName { get; set; }
    public String Sender { get; set; }
    public String Receiver { get; set; }
    public Double Amount { get; set; }
    public String Category { get; set; }
    public DateTime Date { get; set; }
    public String Description { get; set; }
    public int ExpensesId { get; set; }
    
}