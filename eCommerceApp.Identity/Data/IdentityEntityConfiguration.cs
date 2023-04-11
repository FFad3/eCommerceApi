using eCommerceApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerceApp.Identity.Data
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = IdentityDbPopulateConstants.AdminRoleId,
                    Name = IdentityDbPopulateConstants.Admin,
                    NormalizedName = IdentityDbPopulateConstants.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = IdentityDbPopulateConstants.UserRoleId,
                    Name = IdentityDbPopulateConstants.User,
                    NormalizedName = IdentityDbPopulateConstants.User.ToUpper()
                }
                );
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = IdentityDbPopulateConstants.AdminId,
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "System",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null!, "zaq1@WSX"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = IdentityDbPopulateConstants.UserId,
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FirstName = "User",
                    LastName = "User",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null!, "zaq1@WSX"),
                    EmailConfirmed = true,
                });
        }
    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = IdentityDbPopulateConstants.AdminRoleId,
                    UserId = IdentityDbPopulateConstants.AdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = IdentityDbPopulateConstants.UserRoleId,
                    UserId = IdentityDbPopulateConstants.UserId
                }
                );
        }
    }
}