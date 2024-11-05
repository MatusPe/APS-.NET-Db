using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class Loan
{
    [Key]
    public int Id { get; set; }
    public String LoanName { get; set; }
    public String TypeLoad { get; set; }
    public String Lender { get; set; }
    public Double LoanAmount { get; set; }
    public Double InterestRate { get; set; }
    public int term { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Double mounthlyPayment { get; set; }
    public Double totalPayment { get; set; }
    public String Status { get; set; }
    public String Description { get; set; }
    public int WalletId { get; set; }
    
    
}