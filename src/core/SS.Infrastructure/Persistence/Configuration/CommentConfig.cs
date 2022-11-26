using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Blog;

namespace SS.Infrastructure.Persistence.Configuration;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.Property(c => c.LastUpdatedOn);
        builder.HasOne(c => c.ApplicationUser).WithMany()
            .HasForeignKey(c => c.ApplicationUserId);
        builder.HasMany(c => c.Replies);
        builder.HasMany(c => c.Reactions);
    }
}