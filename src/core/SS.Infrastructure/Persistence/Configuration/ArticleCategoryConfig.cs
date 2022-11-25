using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Blog;

namespace SS.Infrastructure.Persistence.Configuration;

public class ArticleCategoryConfig: IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder.ToTable("Article Categories");
        builder.HasKey(at => new {at.ArticleId, at.CategoryId});
        builder.HasOne(at => at.Article)
            .WithMany(at => at.ArticleCategories)
            .HasForeignKey(ac => ac.ArticleId);
        builder.HasOne(at => at.Category)
            .WithMany(at => at.ArticleCategories)
            .HasForeignKey(at => at.CategoryId);
    }
}