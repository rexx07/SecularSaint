using SS.Domain.Contracts;

namespace SS.Domain.Blog;

public class ArticleCategory: AuditableEntity
{
    public Guid ArticleId { get; set; }
    public Article Article { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}