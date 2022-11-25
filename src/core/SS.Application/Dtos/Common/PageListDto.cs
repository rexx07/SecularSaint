using SS.Application.Dtos.Blog;

namespace SS.Application.Dtos.Common;

public class PageListDto
{
    public IEnumerable<ArticleDto> Posts { get; set; }
    public Pager Pager { get; set; }
}