using Microsoft.AspNetCore.Identity;

namespace endterm.Models;

public class User: IdentityUser
{
    public User(
        string login,
        string email)
    {
        UserName = login;
        Email = email;
    }
    
    private User(){}
}