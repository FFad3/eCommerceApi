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
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "AMD 7700X",
                    Price = 100.00M,
                    Description = "This is new AMD processor",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "INTEL 570X",
                    Price = 80.00M,
                    Description = "This is new INTEL processor",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "AMD 1700",
                    Price = 20.00M,
                    Description = "This is new AMD processor",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "CORSAIR PSU 100W",
                    Price = 20.00M,
                    Description = "This is new PSU",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "ASROCK PSU 500W",
                    Price = 40.00M,
                    Description = "This is new PSU",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 2,
                    Name = "RANDOM PSU",
                    Price = 80.00M,
                    Description = "This is new PSU",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Name = "2x4GB DDR4",
                    Price = 42.00M,
                    Description = "This is new RAM",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 8,
                    CategoryId = 3,
                    Name = "2x7GB DDR4",
                    Price = 70.00M,
                    Description = "This is new RAM",
                    ImgUrl = "Comming soon"
                },
                new Product
                {
                    Id = 9,
                    CategoryId = 3,
                    Name = "2x16GB DDR5",
                    Price = 100.00M,
                    Description = "This is new RAM",
                    ImgUrl = "Comming soon"
                });
        }
    }

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Products).WithOne(x => x.Category).OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
            new Category
            {
                Id = 1,
                Name = "CPU"
            },
            new Category
            {
                Id = 2,
                Name = "PSU"
            },
            new Category
            {
                Id = 3,
                Name = "RAM"
            });
        }
    }

    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(e => e.Items).WithOne(e => e.Order).OnDelete(DeleteBehavior.Cascade);
        }
    }

    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(e => e.Order).WithMany(e => e.Items).OnDelete(DeleteBehavior.Cascade);
        }
    }

    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasMany(e => e.Items).WithOne(e => e.Cart).OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasOne(e => e.Cart).WithMany(e => e.Items).OnDelete(DeleteBehavior.Cascade);
        }
    }
}