using SS.Application.Dtos.Common;

namespace SS.Application.Interfaces.Common;

public interface IAnalyticsService
{
    Task<AnalyticsDto> GetAnalytics();
    Task<bool> SaveDisplayType(int type);
    Task<bool> SaveDisplayPeriod(int period);
}