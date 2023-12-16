using System.ComponentModel.DataAnnotations;

namespace endterm.ViewModel.Post;

public class PostAddVm
{
    [Required]
    public string Title { get;  set; }
    
    [Required]
    public string Text { get; set; }
}