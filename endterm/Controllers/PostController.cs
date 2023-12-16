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

        return RedirectToAction("Index", "Home");
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var post = _db.Posts.FirstOrDefault(p => p.Id == id);

        var postUpdate = new PostUpdateVm()
        {
            Id = post.Id,
            Text = post.Text,
            Title = post.Title
        };
        
        return View(postUpdate);
    }


    [HttpPost]
    public async Task<IActionResult> Update(PostUpdateVm model, int postId)
    {
        if (!ModelState.IsValid)
            return View();
        
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound();

        var postDB = _db.Posts.FirstOrDefault(p => p.Id == postId);
        
        postDB.Text = model.Text;
        postDB.Title = model.Title;


        _db.Posts.Update(postDB);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int postId)
    {
        var post = _db.Posts.FirstOrDefault(p => p.Id == postId);
        if (post is null)
            return NotFound();
        
        
        _db.Posts.Remove(post);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }
    
}