using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Common;

namespace SS.Infrastructure.Persistence.Configuration;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.LastUpdatedOn).HasMaxLength(250);
    }
}