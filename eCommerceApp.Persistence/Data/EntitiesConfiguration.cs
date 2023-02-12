using eCommerceApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerceApp.Persistence.Data
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e => e.Category).WithMany(e => e.Products).OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.Description).HasColumnType("nvarchar(600)");
        }
    }

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Products).WithOne(x => x.Category).OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(e => e.Items).WithOne(e => e.Order).OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(e => e.Order).WithMany(e => e.Items).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Product).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasMany(e => e.Items).WithOne(e => e.Basket).OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(e => e.Basket).WithMany(e => e.Items).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Product).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}