/*using SS.Application.Dtos.Common;
using SS.Application.Interfaces.Common;
using SS.Domain.Blog;
using SS.Infrastructure.Persistence.Context;
using SS.Infrastructure.Persistence.Repository;

namespace SS.Infrastructure.Common.Services;

public class AnalyticsService: IAnalyticsService
{
    private readonly RepositoryManager _repository;

    public AnalyticsService(RepositoryManager repository)
    {
        _repository = repository;
    }
    
    public async Task<AnalyticsDto> GetAnalytics()
    {
        var articles = _repository.Article; 
        var articleTypeCount = articles
            .GetArticlesAsync(a => a.ArticleType == ArticleType.Article, true)
            .Result!.Count;
        var articlePageCount = articles
            .GetArticlesAsync(a => a.ArticleType == ArticleType.Page, true)
            .Result!.Count;
        var totalViews
        

        var analytics = new AnalyticsDto
        {
            TotalArticles = 
                
                
        }
    }

    public async Task<bool> SaveDisplayType(int type)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveDisplayPeriod(int period)
    {
        throw new NotImplementedException();
    }
}*/