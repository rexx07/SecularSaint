using SS.Domain.Common;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface IMailSettingRepository
{
    Task<IEnumerable<MailSetting>> GetAllMailSettingsAsync(bool trackChanges);
    Task<MailSetting?> GetMailSettingAsync(Guid mailSettingId, bool trackChanges);
    Void CreateMailSetting(MailSetting mailSetting);
    Void DeleteMailSetting(MailSetting mailSetting);
}