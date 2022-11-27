using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Common;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

internal sealed class MailSettingRepository: RepositoryBase<MailSetting>, IMailSettingRepository
{
    public MailSettingRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<MailSetting>> GetAllMailSettingsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(ml => ml.CreatedOn)
            .ToListAsync();
    }

    public async Task<MailSetting?> GetMailSettingAsync(Guid mailSettingId, bool trackChanges)
    {
       return await FindByCondition(ml => ml.Id == mailSettingId, trackChanges)
           .SingleOrDefaultAsync();
    }

    public void CreateMailSetting(MailSetting mailSetting)
    {
        Create(mailSetting);
    }

    public void DeleteMailSetting(MailSetting mailSetting)
    {
        Delete(mailSetting);
    }
}