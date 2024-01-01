using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sportstore.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Line = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    State = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Zip = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Country = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    GiftWrap = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Category = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "CartLines",
                columns: table => new
                {
                    CartLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLines", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_CartLines_Orders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_CartLines_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "A boat for one person", "Kayak", 275m },
                    { 2, "Watersports", "Protective and fashionable", "Lifejacket", 48.95m },
                    { 3, "Soccer", "FIFA-approved size and weight", "Soccer Ball", 19.50m },
                    { 4, "Soccer", "Give your playing field a professional touch", "Corner Flags", 34.95m },
                    { 5, "Soccer", "Flat-packed 35,000-seat stadium", "Stadium", 79500m },
                    { 6, "Chess", "Improve brain efficiency by 75%", "Thinking Cap", 16m },
                    { 7, "Chess", "Secretly give your opponent a disadvantage", "Unsteady Chair", 29.95m },
                    { 8, "Chess", "A fun game for the family", "Human Chess Board", 75m },
                    { 9, "Chess", "Gold-plated, diamond-studded King", "Bling-Bling King", 1200m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_OrderId",
                table: "CartLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_ProductId",
                table: "CartLines",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
