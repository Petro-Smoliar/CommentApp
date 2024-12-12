namespace CommentApp.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; } = DateTime.Now;
    
    public int UserId { get; set; }
    public User? User { get; set; }
    
    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
}