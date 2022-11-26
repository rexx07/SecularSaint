using SS.Domain.Blog;

namespace SS.Application.Dtos.Blog;

public class ArticleDto
{
    public Guid ArticleId { get; init; }
    public string Title { get; init; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string Content { get; init; }
    public DateTime UpdatedOn { get; init; }
    public string AuthorName { get; init; }
    public bool Edited { get; init; }
    public string? Picture { get; init; }
    public string Cover { get; set; }
    public int ArticleViews { get; set; }
    public double Rating { get; set; }
    public DateTime Published { get; set; }
    public bool Selected { get; set; }
    public bool IsPublished
    {
        get { return Published > DateTime.MinValue; }
    }
    public bool Featured { get; set; }
    public ICollection<CategoryDto> Category { get; init; }
    public int TotReactions { get; init; }
    public int TotComments { get; init; }
}