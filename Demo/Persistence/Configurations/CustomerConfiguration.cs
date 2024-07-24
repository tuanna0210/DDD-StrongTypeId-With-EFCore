using Demo.Domain;
using Demo.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasConversion(id => id.Value, did => CustomerId.Of(did));
            builder.Property(c => c.Name).HasMaxLength(100);
        }
    }
}
