using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;

namespace ReactApp2.Server.UserMappers;

public static class UserMappers
{
    public static User fromUserDTOsToUser(this UserCreateDTOs userDTOs)
    {

        return new User
        {
            Username = userDTOs.Username,
            Password = userDTOs.Password,
            FirstName = userDTOs.FirstName,
            Lastname = userDTOs.Lastname,
            Email = userDTOs.Email,
            Birthday = userDTOs.Birthday,
            Gender = userDTOs.Gender,
            State = userDTOs.State,
            City = userDTOs.City,
            Address = userDTOs.Address,
            ZipCode = userDTOs.ZipCode,
            Phone = userDTOs.Phone,
            
        };


    }
}