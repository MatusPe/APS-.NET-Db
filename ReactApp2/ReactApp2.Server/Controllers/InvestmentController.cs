using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Controllers;

[Route("api/Investment")]
[ApiController]
public class InvestmentController: ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IInvestmentRepositary _investmentRepositary;
    public InvestmentController(ApplicationDbContext context, IInvestmentRepositary investmentRepositary)
    {
        _context = context;
        _investmentRepositary = investmentRepositary;
        
    }
    [HttpGet]
    public async Task<IActionResult> GetALLInvestment()
    {
        var Investment= await _investmentRepositary.GetAllInvestmentAsync();
        return Ok(Investment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvestmentById([FromRoute]int id)
    {
        var investment = await _investmentRepositary.GetInvestmentByIdAsync(id);
        if (investment==null)
        {
            return NotFound();
        }
        return Ok(investment);
    }

    [HttpPost]
    public async Task<IActionResult> AddInvestment([FromBody] Investment investment)
    {
        
        await _investmentRepositary.AddInvestmentAsync(investment);
        
        return CreatedAtAction(nameof(GetInvestmentById), new{id=investment.Id},investment);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateInvestment([FromRoute] int id, [FromBody] Investment investment)
    {
        var oldInvestment =await _investmentRepositary.GetInvestmentByIdAsync(id);
        if (oldInvestment == null)
        {
            return NotFound();
        }
        await _investmentRepositary.UpdateInvestmentAsync(id, investment);
        _context.SaveChangesAsync();
        return Ok(oldInvestment);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteInvestment([FromRoute] int id)
    {
        var investment = await _investmentRepositary.DeleteInvestmentAsync(id);
        if (investment == null)
        {
            return NotFound();
        }
       
        return NoContent();
    } 
    
}