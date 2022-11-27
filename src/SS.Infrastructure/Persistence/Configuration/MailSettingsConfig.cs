using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Common;

namespace SS.Infrastructure.Persistence.Configuration;

public class MailSettingsConfig : IEntityTypeConfiguration<MailSetting>
{
    public void Configure(EntityTypeBuilder<MailSetting> builder)
    {
        builder.ToTable("Mail Settings");
        builder.HasKey(a => a.Id);
        builder.Property(m => m.LastUpdatedOn);
    }
}