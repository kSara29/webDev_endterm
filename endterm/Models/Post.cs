namespace endterm.Models;

public class Post
{
    public int Id { get; init; }
    public string Title { get;  init; }
    public string Text { get; init; }
    public string Author { get; init; }
    public DateTime CreatedAt { get; init; }

    public Post(
        int id, 
        string title,
        string text,
        string author
        )
    {
        Id = id;
        Title = title;
        Text = text;
        Author = author;
        CreatedAt = DateTime.UtcNow;
    }
    
    private Post(){}
}