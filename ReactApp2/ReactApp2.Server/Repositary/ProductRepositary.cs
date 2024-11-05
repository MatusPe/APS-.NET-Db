using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class ProductRepositary:IProductsRepositary
{
    private readonly ApplicationDbContext context;
    public ProductRepositary(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<List<Product>> GetProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return null;
        }
        return product;
    }

    public async Task<Product> addProductAsync(Product product)
    { 
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
        
    }

    public async Task<Product> updateProductAsync(int id, ProductCreateDTOs product)
    {
        var oldProduct = await context.Products.FindAsync(id);
        if (oldProduct == null)
        {
            return null;
        }
        oldProduct.Name = product.Name;
        oldProduct.Name = product.Name;
        oldProduct.Quantity = product.Quantity;
        oldProduct.PricePerUnit = product.PricePerUnit;
        oldProduct.PriceDPH = product.PriceDPH;
        oldProduct.PriceNotDPH = product.PriceNotDPH;
        return oldProduct;
    }

    public async Task<Product> deleteProductAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return null;
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return product;
    }
}