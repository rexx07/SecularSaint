using SS.Domain.Blog;

namespace SS.Application.Dtos.Blog;

public class UpdateArticleRequestDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public bool AllowComments { get; init; }
    public Guid CategoryId { get; init; }
    public PublishedStatus PublishedStatus { get; init; }
    public List<string>? Pictures { get; init; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public ArticleType ArticleType { get; set; }
    public int PostViews { get; set; }
    public double Rating { get; set; }
    public bool IsFeatured { get; set; }
    public bool Selected { get; set; }
    public DateTime Published { get; set; }
    public bool Edited { get; set; }
}