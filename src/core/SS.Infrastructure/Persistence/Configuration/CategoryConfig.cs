using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Blog;

namespace SS.Infrastructure.Persistence.Configuration;

public class CategoryConfig: IEntityTypeConfiguration<Category>
{
    string sql = "getDate()";
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(a => a.Id);
        builder.Property(c => c.LastUpdatedOn).HasDefaultValueSql(sql);
    }
}