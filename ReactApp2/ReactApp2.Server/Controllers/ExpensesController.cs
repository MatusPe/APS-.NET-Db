using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Controllers;

[Route("api/Expenses")]
[ApiController]
public class ExpensesController:ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IExpensesRepositary expensesRepositary;
    public ExpensesController(ApplicationDbContext context, IExpensesRepositary expensesRepositary)
    {
        _context = context;
        this.expensesRepositary = expensesRepositary;
        
    }
    [HttpGet]
    public async Task<IActionResult> GetAllExpenses()
    {
        var budget= await expensesRepositary.GetAllExpensesAsync();
        return Ok(budget);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpensesById([FromRoute]int id)
    {
        var expenses = await expensesRepositary.GetExpensesByIdAsync(id);
        if (expenses==null)
        {
            return NotFound();
        }
        return Ok(expenses);
    }

    [HttpPost]
    public async Task<IActionResult> AddExpenses([FromBody] Expenses expenses)
    {
        
        await expensesRepositary.AddExpensesAsync(expenses);
        
        return CreatedAtAction(nameof(GetExpensesById), new{id=expenses.Id},expenses);
    }
    

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteExpenses([FromRoute] int id)
    {
        var expenses = await expensesRepositary.DeleteExpensesAsync(id);
        
       
        return NoContent();
    } 
}