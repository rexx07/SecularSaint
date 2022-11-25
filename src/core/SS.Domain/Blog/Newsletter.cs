using SS.Domain.Contracts;

namespace SS.Domain.Blog;

public class Newsletter: AuditableEntity
{
    public Guid ArticleId { get; set; }
    public bool Success { get; set; }
    public Article Article { get; set; }
}