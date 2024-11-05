using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;

namespace ReactApp2.Server.UserMappers;

public static class ProductMapper
{
    public static Product FromProductDTOsToProduct(this ProductCreateDTOs productCreateDTOs, int Expendsid)
    {
        return new Product
        {
            Name = productCreateDTOs.Name,
            Quantity = productCreateDTOs.Quantity,
            PricePerUnit = productCreateDTOs.PricePerUnit,
            PriceDPH = productCreateDTOs.PriceDPH,
            PriceNotDPH = productCreateDTOs.PriceNotDPH,
            ExpendsId=Expendsid

        };
    }
    
    public static Product UpdateFromProductDTOsToProduct(this ProductCreateDTOs productCreateDTOs)
    {
        return new Product
        {
            Name = productCreateDTOs.Name,
            Quantity = productCreateDTOs.Quantity,
            PricePerUnit = productCreateDTOs.PricePerUnit,
            PriceDPH = productCreateDTOs.PriceDPH,
            PriceNotDPH = productCreateDTOs.PriceNotDPH,
            

        };
    }
}