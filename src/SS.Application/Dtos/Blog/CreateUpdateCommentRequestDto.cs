namespace SS.Application.Dtos.Blog;

public class CreateUpdateCommentRequestDto
{
    public List<string>? Pictures { get; set; }
    public string Content { get; set; }
}