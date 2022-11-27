using SS.Domain.Contracts;

namespace SS.Domain.Blog;

public class Category : AuditableEntity
{
    public string Content { get; set; }
    public string Description { get; set; }
    public ICollection<ArticleCategory> ArticleCategories { get; set; }
}