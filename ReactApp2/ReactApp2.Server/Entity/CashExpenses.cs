using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class CashExpenses
{
    [Key]
    public int Id { get; set; }
    
    public String Type{ get; set; }
    public String Company{ get; set; }
    public int Quantity { get; set; }
    public int TotalPriceDPH { get; set; }
    public int TotalPriceNotDPH { get; set; }
    public DateTime ExpendDate { get; set; }
    public List<Product> Products { get; set; }
    public String Description { get; set; }
    
    
    public int ExpensesId { get; set; }
    
    
    
}