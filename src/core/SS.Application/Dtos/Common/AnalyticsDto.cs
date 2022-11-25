using SS.Domain.Blog;

namespace SS.Application.Dtos.Common;

public class AnalyticsDto
{
    public int TotalArticles { get; set; }
    public int TotalPages { get; set; }
    public int TotalViews { get; set; }
    public int TotalSubscribers { get; set; }
    public AnalyticsListType DisplayType { get; set; }
    public AnalyticsPeriod DisplayPeriod { get; set; }
    //public BarChartModel LatestPostViews { get; set; }
}