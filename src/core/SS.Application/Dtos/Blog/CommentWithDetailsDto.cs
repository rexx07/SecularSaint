namespace SS.Application.Dtos.Blog;

public class CommentWithDetailsDto
{
    public List<string>? Pictures { get; set; }
    public string Content { get; set; }
    public string Username { get; set; }
    public bool Edited { get; set; }
    public List<string>? Edits { get; set; }
    public List<DateTime>? EditsTimes { get; set; }
    public ICollection<CommentDto>? Replies { get; set; }
    public ICollection<ReactionDto>? Reactions { get; set; }
}