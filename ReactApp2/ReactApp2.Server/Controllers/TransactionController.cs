using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Controllers;
[Route("api/Transaction")]
[ApiController]
public class TransactionController:ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ITransactionRepositary TransactionRepositary;
    public TransactionController(ApplicationDbContext context, ITransactionRepositary transactionRepositary)
    {
        _context = context;
        TransactionRepositary = transactionRepositary;
        
    }
    [HttpGet]
    public async Task<IActionResult> GetALLTransaction()
    {
        var transaction= await TransactionRepositary.GetAllTransactionAsync();
        return Ok(transaction);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionById([FromRoute]int id)
    {
        var transaction = await TransactionRepositary.GetTransactionByIdAsync(id);
        if (transaction==null)
        {
            return NotFound();
        }
        return Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
    {
        
        await TransactionRepositary.AddTransactionAsync(transaction);
        
        return CreatedAtAction(nameof(GetTransactionById), new{id=transaction.Id},transaction);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateTransaction([FromRoute] int id, [FromBody] Transaction transaction)
    {
        var oldTransaction =await TransactionRepositary.GetTransactionByIdAsync(id);
        if (oldTransaction == null)
        {
            return NotFound();
        }
        await TransactionRepositary.UpdateTransactionAsync(id, transaction);
        return Ok(oldTransaction);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
    {
        var transaction = await TransactionRepositary.DeleteTransactionAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }
       
        return NoContent();
    } 
}