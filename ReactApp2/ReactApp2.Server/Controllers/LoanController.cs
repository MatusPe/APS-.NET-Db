using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Controllers;
[Route("api/Loan")]
[ApiController]
public class LoanController: ControllerBase
{
    public readonly ApplicationDbContext _context;
    public readonly ILoanRepositary Repositary;
    
    
    public LoanController(ApplicationDbContext dbContext, ILoanRepositary Repositary)
    {
        _context = dbContext;
        this.Repositary = Repositary;
    }

    [HttpGet]
    public async Task<IActionResult> GetALLLoan()
    {
        var Loan= await Repositary.GetAllLoanAsync();
        return Ok(Loan);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanById([FromRoute]int id)
    {
        var wallet = await Repositary.GetLoanByIdAsync(id);
        if (wallet==null)
        {
            return NotFound();
        }
        return Ok(wallet);
    }

    [HttpPost]
    public async Task<IActionResult> AddLoan([FromBody] Loan loan)
    {
        
        await Repositary.AddLoanAsync(loan);
        
        return CreatedAtAction(nameof(GetLoanById), new{id=loan.Id},loan);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateLoan([FromRoute] int id, [FromBody] Loan loan)
    {
        var oldloan =await Repositary.GetLoanByIdAsync(id);
        if (oldloan == null)
        {
            return NotFound();
        }
        await Repositary.UpdateLoanAsync(id, loan);
        
        return Ok(oldloan);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteLoan([FromRoute] int id)
    {
        var wallet = await Repositary.DeleteLoanAsync(id);
        if (wallet == null)
        {
            return NotFound();
        }
       
        return NoContent();
    } 

}