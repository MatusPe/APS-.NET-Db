using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;
using ReactApp2.Server.UserMappers;

namespace ReactApp2.Server.Controllers;


[Route("App/UserController")]
[ApiController]
public class UserController:ControllerBase
{

    public readonly ApplicationDbContext _context;
    public readonly IUserRepositary _userRepositary;
    
    
    public UserController(ApplicationDbContext dbContext, IUserRepositary userRepositary)
    {
        _context = dbContext;
        _userRepositary = userRepositary;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var User= await _userRepositary.GetAllAsync();
        return Ok(User);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute]int id)
    {
        var User = await _userRepositary.GetUserByIdAsync(id);
        if (User==null)
        {
            return NotFound();
        }
        return Ok(User);
    }

    [HttpPost]
    public async Task<IActionResult> addUser([FromBody] UserCreateDTOs user)
    {
        var Usermodel = user.fromUserDTOsToUser();
        await _userRepositary.AddUserAsync(Usermodel);
        
        return CreatedAtAction(nameof(GetUserById), new{id=Usermodel.id}, Usermodel);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserCreateDTOs user)
    {
        var UserModel =await _userRepositary.GetUserByIdAsync(id);
        if (UserModel == null)
        {
            return NotFound();
        }
        await _userRepositary.UpdateUserByIdAsync(id, user.fromUserDTOsToUser());
        
        return Ok(UserModel);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var User = await _userRepositary.DeleteUserByIdAsync(id);
        if (User == null)
        {
            return NotFound();
        }
       
        return NoContent();
    }
    
    
    
}