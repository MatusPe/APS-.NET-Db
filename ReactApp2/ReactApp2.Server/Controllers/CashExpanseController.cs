using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;
using ReactApp2.Server.UserMappers;

namespace ReactApp2.Server.Controllers;

[Route("api/CashExpanse")]
[ApiController]
public class CashExpanseController: ControllerBase
{
    private readonly ApplicationDbContext context;
    private readonly ICashExpenseRepositary repo;
    private readonly IUserRepositary user;
    public CashExpanseController(ApplicationDbContext context, ICashExpenseRepositary repository, IUserRepositary userRepository)
    {
        this.context = context;
        repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetExpanses()
    {
        var Expanse=await repo.GetAllExpendsAsync();
        return Ok(Expanse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpansebyId(int id)
    {
        var expendById = await repo.GetExpendByIdAsync(id);
        if (expendById == null)
        {
            return NotFound();
        }
        
        return Ok(expendById);
    }

    [HttpPost("{Expenseid}")]
    public async Task<IActionResult> AddExpense([FromRoute] int Expenseid, ExpanseDTOs expends)
    {
        

        var ExpenseModel = expends.fromExpenseDTOsToExpense(Expenseid);
        if (ExpenseModel == null)
        {
            return BadRequest();
        }
        await repo.AddExpenseAsync(ExpenseModel);
        return CreatedAtAction(nameof(GetExpansebyId), new { id = ExpenseModel.Id }, ExpenseModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense([FromRoute] int id, [FromBody] ExpanseDTOs expends)
    {
        var ExpenseModel = expends.fromExpenseDTOsToExpense(id);
        await repo.UpdateExpenseAsync(id, ExpenseModel);
        
        return Ok(ExpenseModel);
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense([FromRoute] int id)
    {
        await repo.DeleteExpenseAsync(id);
        return NoContent();
    }
}