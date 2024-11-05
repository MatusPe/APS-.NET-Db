using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;
using ReactApp2.Server.UserMappers;

namespace ReactApp2.Server.Controllers;
[Route("api/Wallet")]
[ApiController]
public class WalletController: ControllerBase
{
    public readonly ApplicationDbContext _context;
    public readonly IWalletRepositary Repositary;
    
    
    public WalletController(ApplicationDbContext dbContext, IWalletRepositary Repositary)
    {
        _context = dbContext;
        this.Repositary = Repositary;
    }

    [HttpGet]
    public async Task<IActionResult> GetWallet()
    {
        var wallet= await Repositary.GetAllWalletAsync();
        return Ok(wallet);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWalletById([FromRoute]int id)
    {
        var wallet = await Repositary.GetWalletByIdAsync(id);
        if (wallet==null)
        {
            return NotFound();
        }
        return Ok(wallet);
    }

    [HttpPost]
    public async Task<IActionResult> addWallet([FromBody] Wallet wallet)
    {
        
        await Repositary.AddWalletAsync(wallet);
        
        return CreatedAtAction(nameof(GetWalletById), new{id=wallet.Id}, wallet);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateWallet([FromRoute] int id, [FromBody] Wallet wallet)
    {
        var oldwallet =await Repositary.GetWalletByIdAsync(id);
        if (wallet == null)
        {
            return NotFound();
        }
        await Repositary.UpdateWalletAsync(id, wallet);
        
        return Ok(oldwallet);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteWallet([FromRoute] int id)
    {
        var wallet = await Repositary.DeleteWalletAsync(id);
        if (wallet == null)
        {
            return NotFound();
        }
       
        return NoContent();
    } 
    
}