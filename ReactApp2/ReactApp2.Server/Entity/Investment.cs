using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class Investment
{
    [Key]
    public int Id { get; set; }
    public String InvestType { get; set; }
    public String InvestmentStock { get; set; }
    public String InvestmentAmount { get; set; }
    public String InvestmentProfit { get; set; }
    public DateTime InvestmentDate { get; set; }
    public DateTime Duration { get; set; }
    public String investmentDescription { get; set; }
    public int WalletId { get; set; }
    
}