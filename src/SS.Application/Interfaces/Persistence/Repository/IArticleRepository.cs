using System.Linq.Expressions;
using SS.Domain.Blog;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges);
    Task<List<Article>?> GetArticlesAsync(Expression<Func<Article, bool>> expression, bool trackChanges);
    void CreateArticle(Article article);
    void DeleteArticle(Article article);
}