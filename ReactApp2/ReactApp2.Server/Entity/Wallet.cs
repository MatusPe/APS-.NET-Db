using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class Wallet
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Loan> ListLoan{get;set;}
    public List<Investment> ListInvestments{get;set;}
    public List<Budget> ListBudgets{get;set;}
    public List<Expenses> Expenses{get;set;}
    
}