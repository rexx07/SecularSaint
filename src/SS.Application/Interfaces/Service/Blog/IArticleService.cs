using SS.Application.Dtos.Blog;

namespace SS.Application.Interfaces.Service.Blog;

public interface IArticleService
{
    Task<IEnumerable<ArticleDto>> GetAllArticlesAsync(bool trackChanges);
    Task<IEnumerable<ArticleDto>> SearchArticlesAsync(IEnumerable<Guid> articleIds, bool trackChanges);
    Task<ArticleWithDetailsDto> GetArticleAsync(Guid articleId, bool trackChanges);

    Task<ArticleDto> CreateArticleAsync(CreateArticleRequestDto article, bool trackChanges);

    Task UpdateArticleAsync(Guid articleId, UpdateArticleRequestDto article, bool trackChanges);
    Task DeleteArticleAsync(Guid articleId, bool trackChanges);
}