using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Common;

namespace SS.Infrastructure.Persistence.Configuration;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.LastUpdatedOn).HasMaxLength(250);
    }
}