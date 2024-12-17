namespace CommentApp.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string HomePage { get; set; }
    public string Username { get; set; }
    public string Email{ get; set; }
    public string Text { get; set; }
    public DateTime Date { get; } = DateTime.Now;
    
    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
}