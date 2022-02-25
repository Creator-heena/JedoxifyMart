using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JedoxifyMart.Services.StateAPI.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "states",
                newName: "DayOfWeek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "states",
                newName: "StateName");
        }
    }
}
