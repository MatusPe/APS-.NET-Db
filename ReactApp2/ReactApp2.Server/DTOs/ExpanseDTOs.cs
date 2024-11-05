namespace ReactApp2.Server.DTOs;

public class ExpanseDTOs
{
    public String Type{ get; set; }
    public String Company{ get; set; }
    public int Quantity { get; set; }
    public int TotalPriceDPH { get; set; }
    public int TotalPriceNotDPH { get; set; }
    public String Description { get; set; }
    public DateTime ExpendDate { get; set; }
}