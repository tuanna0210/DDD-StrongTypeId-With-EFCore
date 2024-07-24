using Demo.Domain;
using Demo.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Persistence.Configurations
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(c => c.Id)
                .HasConversion(id => id.Value, did => MenuId.Of(did));

            builder.HasMany(m => m.Customers)
                .WithOne();
        }
    }
}
