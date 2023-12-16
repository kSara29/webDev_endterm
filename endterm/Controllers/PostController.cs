using endterm.Database;
using endterm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace endterm.Controllers;

public class PostController: Controller
{
    private readonly AppDbContext _db;
    private readonly UserManager<User> _userManager;

    public PostController(
        AppDbContext db,
        UserManager<User> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return Ok();
    }
}