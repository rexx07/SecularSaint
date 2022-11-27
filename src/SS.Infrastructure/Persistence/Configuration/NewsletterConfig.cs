using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Blog;

namespace SS.Infrastructure.Persistence.Configuration;

public class NewsletterConfig : IEntityTypeConfiguration<Newsletter>
{
    public void Configure(EntityTypeBuilder<Newsletter> builder)
    {
        builder.ToTable("Newsletter");
        builder.HasKey(a => a.Id);
        builder.Property(n => n.LastUpdatedOn);
    }
}