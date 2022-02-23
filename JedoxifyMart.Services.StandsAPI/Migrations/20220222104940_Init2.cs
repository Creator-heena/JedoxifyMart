using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JedoxifyMart.Services.StandsAPI.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stand",
                columns: table => new
                {
                    StandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stand", x => x.StandId);
                });

            migrationBuilder.CreateTable(
                name: "StandDetails",
                columns: table => new
                {
                    StandDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandDetails", x => x.StandDetailId);
                    table.ForeignKey(
                        name: "FK_StandDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandDetails_Stand_StandId",
                        column: x => x.StandId,
                        principalTable: "Stand",
                        principalColumn: "StandId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandDetails_ProductId",
                table: "StandDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StandDetails_StandId",
                table: "StandDetails",
                column: "StandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stand");
        }
    }
}
