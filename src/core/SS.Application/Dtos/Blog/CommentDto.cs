namespace SS.Application.Dtos.Blog;

public class CommentDto
{
    public Guid CommentId { get; init; }
    public string? Picture { get; init; }
    public DateTime UpdatedOn { get; init; }
    public string Content { get; init; }
    public string Username { get; init; }
    public int TotReplies { get; init; }
    public int TotReactions { get; init; }
}