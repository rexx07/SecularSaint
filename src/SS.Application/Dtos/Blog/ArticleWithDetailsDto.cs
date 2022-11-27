using SS.Domain.Blog;

namespace SS.Application.Dtos.Blog;

public class ArticleWithDetailsDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime UpdatedOn { get; init; }
    public PublishedStatus PublishedStatus { get; init; }
    public string Author { get; init; }
    public bool Edited { get; init; }
    public List<string>? Edits { get; init; }
    public List<DateTime>? EditsTimes { get; init; }
    public List<string>? Pictures { get; init; }
    public List<string> Tags { get; init; }
    public Guid ArticleId { get; init; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string AuthorName { get; init; }
    public string? Picture { get; init; }
    public string Cover { get; set; }
    public int ArticleViews { get; set; }
    public double Rating { get; set; }
    public DateTime Published { get; set; }

    public bool IsPublished => Published > DateTime.MinValue;

    public bool Featured { get; set; }
    public SaveStatus Status { get; set; }
    public List<SocialField> SocialFields { get; set; }
    public bool Selected { get; set; }
    public int TotReactions { get; init; }
    public int TotComments { get; init; }
    public ICollection<CategoryDto> Category { get; init; }
    public ICollection<ReactionDto>? Reactions { get; init; }
    public ICollection<CommentDto>? Comments { get; init; }

    public bool Equals(ArticleWithDetailsDto other)
    {
        if (ArticleId == other.ArticleId)
            return true;
        return false;
    }

    public override int GetHashCode()
    {
        return ArticleId.GetHashCode();
    }
}