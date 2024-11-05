using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;
using ReactApp2.Server.Repositary;
using ReactApp2.Server.UserMappers;

namespace ReactApp2.Server.Controllers;

[Route("api/Product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext context;
    private readonly IProductsRepositary productRepositary;
    private readonly ICashExpenseRepositary _cashExpenseRepositary;

    public ProductController(ApplicationDbContext context, IProductsRepositary productRepositary,
        ICashExpenseRepositary cashExpenseRepositary)
    {
        this.context = context;
        this.productRepositary = productRepositary;
        this._cashExpenseRepositary = cashExpenseRepositary;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var Products = await productRepositary.GetProductsAsync();
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductBy([FromRoute] int id)
    {
        var product = await productRepositary.GetProductByIdAsync(id);
        return Ok(product);

    }

    [HttpPost("{Expenseid}")]

    public async Task<IActionResult> AddProduct([FromRoute] int Expenseid, [FromBody] ProductCreateDTOs product)
    {
        var productModel = product.FromProductDTOsToProduct(Expenseid);
        await productRepositary.addProductAsync(productModel);
        return CreatedAtAction(nameof(GetProductBy), new { id = productModel.Id }, productModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductCreateDTOs product)
    {

        var productModel = await productRepositary.updateProductAsync(id, product);
        context.SaveChanges();
        return Ok(productModel);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var productModel = await productRepositary.deleteProductAsync(id);
        return NoContent();
    }

}