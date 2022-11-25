namespace SS.Application.Dtos.Blog;

public class ArticleModel
{
    public ArticleDto Post { get; set; }
    public ArticleDto Older { get; set; }
    public ArticleDto Newer { get; set; }
    public IEnumerable<ArticleDto> Related { get; set; }
}