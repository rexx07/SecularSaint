namespace SS.Application.Dtos.Common;

public class ChartModel
{
    public ICollection<string> Labels { get; set; }
    public ICollection<int> Data { get; set; }
}