using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Core.Entity
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(id => id.Value, value => new CustomerId(value));


            builder.OwnsOne(c => c.Name, p =>
            {
                p.Property(name => name.Value)
                    .HasColumnName("Name");
                p.WithOwner();
            });

            builder.OwnsOne(c => c.StudioId, p =>
            {
                p.Property(id => id.Value)
                    .HasColumnName("StudioId");
                p.WithOwner();
            });

        }
    }
}