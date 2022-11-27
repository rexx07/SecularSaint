namespace SS.Application.Interfaces.Common;

public interface IExcelWriter : ITransientService
{
    Stream WriteToStream<T>(IList<T> data);
}