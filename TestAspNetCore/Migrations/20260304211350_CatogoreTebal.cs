using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class CatogoreTebal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatogoreId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatogoreId",
                table: "Items");
        }
    }
}
