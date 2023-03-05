using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Card",
                table: "EmpolyeeStatistics");

            migrationBuilder.DropColumn(
                name: "Cash",
                table: "EmpolyeeStatistics");

            migrationBuilder.DropColumn(
                name: "VipCard",
                table: "EmpolyeeStatistics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Card",
                table: "EmpolyeeStatistics",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Cash",
                table: "EmpolyeeStatistics",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VipCard",
                table: "EmpolyeeStatistics",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
