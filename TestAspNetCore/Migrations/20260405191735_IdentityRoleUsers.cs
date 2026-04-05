using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d6b9726-98bc-4465-a6ad-17e70f6f3a8b", "a5b2026c-25bd-4280-85cb-68bc865b0a7f", "Admin", "admin" },
                    { "7c20ff38-5d29-4feb-9271-2bcf3bb10af5", "5eaa0b93-6cf1-4cfb-8863-9f345eebc528", "User", "user" },
                    { "d2bb88cd-9ab6-4fec-979a-38af526edc8d", "197c50bf-8396-4153-ba5f-cc567d2f39d4", "Employee", "employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d6b9726-98bc-4465-a6ad-17e70f6f3a8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c20ff38-5d29-4feb-9271-2bcf3bb10af5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bb88cd-9ab6-4fec-979a-38af526edc8d");
        }
    }
}
