using SS.Application.Interfaces.Common;
using SS.Domain.Common;

namespace SS.Application.FileStorage;

public interface IFileStorageService : ITransientService
{
    public Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType,
        CancellationToken cancellationToken = default)
        where T : class;

    public void Remove(string? path);
}