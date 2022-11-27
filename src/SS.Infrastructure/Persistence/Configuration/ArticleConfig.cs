using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Blog;

namespace SS.Infrastructure.Persistence.Configuration;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.Property(a => a.LastUpdatedOn).HasMaxLength(250);
        builder.HasOne(a => a.ApplicationUser)
            .WithMany().HasForeignKey(a => a.ApplicationUserId);
        builder.HasMany(a => a.Reactions).WithOne();
        builder.HasMany(a => a.Comments).WithOne();
    }
}