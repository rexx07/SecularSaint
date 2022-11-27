using SS.Application.Dtos.Blog;
using SS.Domain.Blog;

namespace SS.Application.Dtos.Common;

public class ListModel
{
    public string Author { get; set; } // posts by author
    public string Category { get; set; } // posts by category

    public IEnumerable<ArticleDto> Posts { get; set; }
    public Pager Pager { get; set; }

    public ArticleListType ArticleListType { get; set; }
}