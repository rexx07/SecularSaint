using SS.Application.Interfaces.Common;

namespace SS.Application.Mailing;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request, CancellationToken ct);
}