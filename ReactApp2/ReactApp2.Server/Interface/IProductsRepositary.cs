using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface IProductsRepositary
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> addProductAsync(Product product);
    Task<Product> updateProductAsync(int id, ProductCreateDTOs product);
    Task<Product> deleteProductAsync(int id);
    
    
}