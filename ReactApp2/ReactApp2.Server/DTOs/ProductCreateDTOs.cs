namespace ReactApp2.Server.DTOs;

public class ProductCreateDTOs
{
    public string Name { get; set; }
    
    public int Quantity { get; set; }
    public int PricePerUnit { get; set; }
    public int PriceDPH { get; set; }
    public int PriceNotDPH { get; set; }
}