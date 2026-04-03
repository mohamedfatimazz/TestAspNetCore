using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class categoretTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorecs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categorecs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SelectCategore" },
                    { 2, "Mobel " },
                    { 3, "Laptop " },
                    { 4, "Computer " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CatogoreId",
                table: "Items",
                column: "CatogoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categorecs_CatogoreId",
                table: "Items",
                column: "CatogoreId",
                principalTable: "Categorecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categorecs_CatogoreId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Categorecs");

            migrationBuilder.DropIndex(
                name: "IX_Items_CatogoreId",
                table: "Items");
        }
    }
}
