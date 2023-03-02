using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typeOfPrice",
                table: "Cassas",
                newName: "TypeOfPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfPrice",
                table: "Cassas",
                newName: "typeOfPrice");
        }
    }
}
