using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "003", "u002" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "003");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "001",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "002", "u002" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u001",
                columns: new[] { "ConcurrencyStamp", "LastName", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "fcf2f1f1-2d93-442c-9e97-2b8dd9dbdcf1", "System", "AQAAAAIAAYagAAAAEOqDu5/nF4t39A0SOm2jDGvyuzjRg74NsAOqARwt+LDDDfdi2lCyKw2BySaXUjl+EA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "641b74ec-bc46-4c26-a902-90d6db8d5764" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u002",
                columns: new[] { "ConcurrencyStamp", "FirstName", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "a167ffbc-71af-4418-8904-aec4406c2bf1", "User", "AQAAAAIAAYagAAAAECsf73oJ0Mwlxi7sOF+fAO3b2MXjYG9gD2Aydt9zBfqoOz4t+O60WHj70OspLQoWWA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "725d917c-51ce-4e0d-ae27-c7f9b338b0f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "002", "u002" });

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "001",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "003", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u001",
                columns: new[] { "ConcurrencyStamp", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff6b9e6-9944-497d-8a89-9920193d3b31", "Admin", "AQAAAAIAAYagAAAAEBRJoLGqU+4fHhfhnwu8ikb7d6iFv2V0RibIPN6fU/2ZJ6OEDqDjdVV6rU3z9UN6ag==", "16ca156c-c167-4527-83f9-fb67434bb35c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u002",
                columns: new[] { "ConcurrencyStamp", "FirstName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c18d96e7-b2b9-4904-a4bd-ec486f1e876f", "System", "AQAAAAIAAYagAAAAENlnIgWWJrmfyH0b4jfjYutRV//gBZ2hPcIbfduvAD/wPKTa0apSaCebEn3Y2kG/6g==", "70970a91-8b8a-41ef-83cc-876aeb50690d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "003", "u002" });
        }
    }
}
