using Microsoft.AspNetCore.Identity;

namespace endterm.Models;

public class User: IdentityUser
{
    public User(
        string login,
        string email,
        string phoneNumber)
    {
        UserName = login;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    
    private User(){}
}