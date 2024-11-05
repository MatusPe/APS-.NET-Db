using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Quantity { get; set; }
    public int PricePerUnit { get; set; }
    public int PriceDPH { get; set; }
    public int PriceNotDPH { get; set; }
    public String Description { get; set; }
    
    
    public int ExpendsId { get; set; }
    
    
    
}