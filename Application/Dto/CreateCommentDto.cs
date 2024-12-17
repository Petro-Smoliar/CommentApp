namespace Application.Dto;

public class CreateCommentDto
{
    public string HomePage { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email{ get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Captcha { get; set; } = string.Empty;
    
    public int? ParentCommentId { get; set; }
}