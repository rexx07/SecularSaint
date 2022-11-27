using SS.Domain.Blog;

namespace SS.Application.Dtos.Blog;

public class CreateArticleRequestDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public bool AllowComments { get; init; }
    public CategoryDto Category { get; init; }
    public PublishedStatus PublishedStatus { get; init; }
    public Guid UserId { get; init; }
    public List<string>? Pictures { get; init; }
}