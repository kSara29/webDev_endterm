using endterm.Database;
using endterm.Models;
using endterm.ViewModel.Post;
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
    
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(PostAddVm model)
    {
        if (!ModelState.IsValid)
            return View();
        
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound();
        
        Post? post = new Post(
           model.Title,
           model.Text,
           user.Id
        );
        
        await _db.Posts.AddAsync(post);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index", "Post");
    }
    
    
}