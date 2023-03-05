using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    public partial class CreateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpolyeeStatistics_Users_UserId",
                table: "EmpolyeeStatistics");

            migrationBuilder.DropIndex(
                name: "IX_EmpolyeeStatistics_UserId",
                table: "EmpolyeeStatistics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmpolyeeStatistics_UserId",
                table: "EmpolyeeStatistics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpolyeeStatistics_Users_UserId",
                table: "EmpolyeeStatistics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
