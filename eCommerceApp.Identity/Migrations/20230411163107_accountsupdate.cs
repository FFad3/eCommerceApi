using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class accountsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "001", "u001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "003", "u002" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u002");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56d441a5-bfb6-4bf6-a4c6-4d6b0c6f11ad", null, "Admin", "ADMIN" },
                    { "d71f9320-3c57-4b17-a4ec-01c4f6b4e4ab", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1530663-8c3b-4e2d-bcc3-1a65c1d1219e", 0, "6b2e6fdc-e2f6-4665-a97e-8cd012ff5e7b", "admin@localhost.com", true, "System", "System", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHFHqjVrPLHZMAYkI4434y7AnR5DyVmqO//51AL5qF/84k965yObSurR/RWQzNG1qw==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "97de55da-abfb-42d6-bfad-64eb5e76a582", false, "admin@localhost.com" },
                    { "e7b078c8-979e-4e1e-9550-69c93b9cf9ee", 0, "7e2f9db4-7c2b-425a-b39e-8acff10709c8", "user@localhost.com", true, "User", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEN7UqW0oi52wp+FkYBeIl4d45HiWu8Lw/wZj0Uz8mNMy+fLMHNnYB35m4rUW0TCVwg==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "798998fa-762e-439e-9050-964940488b00", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "56d441a5-bfb6-4bf6-a4c6-4d6b0c6f11ad", "a1530663-8c3b-4e2d-bcc3-1a65c1d1219e" },
                    { "d71f9320-3c57-4b17-a4ec-01c4f6b4e4ab", "e7b078c8-979e-4e1e-9550-69c93b9cf9ee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56d441a5-bfb6-4bf6-a4c6-4d6b0c6f11ad", "a1530663-8c3b-4e2d-bcc3-1a65c1d1219e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d71f9320-3c57-4b17-a4ec-01c4f6b4e4ab", "e7b078c8-979e-4e1e-9550-69c93b9cf9ee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56d441a5-bfb6-4bf6-a4c6-4d6b0c6f11ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d71f9320-3c57-4b17-a4ec-01c4f6b4e4ab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1530663-8c3b-4e2d-bcc3-1a65c1d1219e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7b078c8-979e-4e1e-9550-69c93b9cf9ee");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "001", null, "Administrator", "ADMINISTRATOR" },
                    { "002", null, "Employee", "EMPLOYEE" },
                    { "003", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "u001", 0, "fff6b9e6-9944-497d-8a89-9920193d3b31", "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBRJoLGqU+4fHhfhnwu8ikb7d6iFv2V0RibIPN6fU/2ZJ6OEDqDjdVV6rU3z9UN6ag==", null, false, "16ca156c-c167-4527-83f9-fb67434bb35c", false, "admin@localhost.com" },
                    { "u002", 0, "c18d96e7-b2b9-4904-a4bd-ec486f1e876f", "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAENlnIgWWJrmfyH0b4jfjYutRV//gBZ2hPcIbfduvAD/wPKTa0apSaCebEn3Y2kG/6g==", null, false, "70970a91-8b8a-41ef-83cc-876aeb50690d", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "001", "u001" },
                    { "003", "u002" }
                });
        }
    }
}
