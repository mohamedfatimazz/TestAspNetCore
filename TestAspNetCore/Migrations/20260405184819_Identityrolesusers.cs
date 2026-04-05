using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class Identityrolesusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "177b6ff0-1a70-40f3-8b3e-69e558ca7bf7", "d7682cdf-5d05-4c4e-84c4-42c820b78c73", "Admin", "Admin" },
                    { "d1f7b06b-5a12-4926-ac85-91967dc8f1a7", "8b0a936b-9c2f-45f4-aefe-3a40b74f6fd3", "User", "User" },
                    { "e1858198-a035-48cf-901d-a66e04b35ac1", "bbaa060f-3135-4b1f-82ba-55b8ee7af52e", "Employee", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "177b6ff0-1a70-40f3-8b3e-69e558ca7bf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1f7b06b-5a12-4926-ac85-91967dc8f1a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1858198-a035-48cf-901d-a66e04b35ac1");
        }
    }
}
