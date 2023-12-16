namespace endterm.Models;

public class Post
{
    public int Id { get; init; }
    public string Title { get;  init; }
    public string Text { get; init; }
    
    public string UserId { get; set;  }
    public User? User { get; set; }
    public DateTime CreatedAt { get; init; }

    public Post(
        int id, 
        string title,
        string text,
        string userId
        )
    {
        Id = id;
        Title = title;
        Text = text;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }
    
    private Post(){}
}