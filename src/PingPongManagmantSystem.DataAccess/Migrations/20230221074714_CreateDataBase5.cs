using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    public partial class CreateDataBase5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Transfers");

            migrationBuilder.AlterColumn<double>(
                name: "TransferSum",
                table: "DesktopCassas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Transfers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Time",
                table: "Transfers",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "TransferSum",
                table: "DesktopCassas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
