using Demo.Domain.MenuAggregate;
using Demo.Domain.MenuAggregate.ValueObjects;
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

            builder.OwnsOne(m => m.AverageRating);

            builder.OwnsMany(m => m.Sections, sectionBuilder =>
            {
                sectionBuilder.ToTable("MenuSections");

                sectionBuilder.Property(m => m.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Of(value)
                    );
                sectionBuilder
                    .Property(s => s.Name)
                    .HasMaxLength(100);

                sectionBuilder
                    .Property(s => s.Description)
                    .HasMaxLength(100);
            });

            builder.HasMany(m => m.Customers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
