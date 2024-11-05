using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class UserRepositary: IUserRepositary
{
    private readonly ApplicationDbContext DbContext;
    public UserRepositary(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var Users= await DbContext.Users.Include(c=>c.Wallets).ToListAsync();
        return Users;
    }

    public async Task<User> AddUserAsync(User user)
    {
        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await DbContext.Users.
            Include(c=>c.Wallets).FirstOrDefaultAsync(i=>i.id==id);
        

        return user;
    }

    public async Task<User?> DeleteUserByIdAsync(int id)
    {
        var userModel = DbContext.Users.Find(id);
        if (userModel == null)
        {
            return null;
        }
        DbContext.Users.Remove(userModel);
        await DbContext.SaveChangesAsync();
        return userModel;
    }

    public async Task<User?> UpdateUserByIdAsync(int id, User user)
    {
        var UserModel = await DbContext.Users.FindAsync(id);
        if (UserModel == null)
        {
            await AddUserAsync(user);
        }
        UserModel.Username = user.Username;
        UserModel.Password = user.Password;
        UserModel.FirstName = user.FirstName;
        UserModel.Lastname = user.Lastname;
        UserModel.Email = user.Email;
        UserModel.Birthday = user.Birthday;
        UserModel.Gender = user.Gender;
        UserModel.State = user.State;
        UserModel.City = user.City;
        UserModel.Address = user.Address;
        UserModel.ZipCode = user.ZipCode;
        UserModel.Phone = user.Phone;
        await DbContext.SaveChangesAsync();
        return UserModel;
    }

    public Task<User?> GetUserbyUsernameAndPassword(string Username, string Password)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserbyEmail(string Email)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckIfUserExists(int id)
    {
        return await DbContext.Users.AnyAsync(i => i.id == id);
    }
}