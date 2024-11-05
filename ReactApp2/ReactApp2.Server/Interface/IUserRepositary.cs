using Microsoft.AspNetCore.Mvc;
using ReactApp2.Server.Entity;

namespace ReactApp2.Server.Interface;

public interface IUserRepositary
{
    Task<List<User>> GetAllAsync();
    Task<User> AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> DeleteUserByIdAsync(int id);
    Task<User?> UpdateUserByIdAsync(int id, User user);
    Task<User?> GetUserbyUsernameAndPassword(string Username, string Password);
    Task<User?> GetUserbyEmail(string Email);
    Task<bool> CheckIfUserExists(int id);
    
    
    
}