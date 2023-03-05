using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    public partial class CreateDateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<string>(type: "TEXT", nullable: false),
                    Card = table.Column<double>(type: "REAL", nullable: false),
                    Cash = table.Column<double>(type: "REAL", nullable: false),
                    BarSum = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfSaleBar = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<string>(type: "TEXT", nullable: false),
                    Card = table.Column<double>(type: "REAL", nullable: false),
                    Cash = table.Column<double>(type: "REAL", nullable: false),
                    SportSum = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfSaleSport = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<string>(type: "TEXT", nullable: false),
                    Card = table.Column<double>(type: "REAL", nullable: false),
                    Cash = table.Column<double>(type: "REAL", nullable: false),
                    VipCard = table.Column<double>(type: "REAL", nullable: false),
                    TableSum = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableStatistics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarStatistics");

            migrationBuilder.DropTable(
                name: "SportStatistics");

            migrationBuilder.DropTable(
                name: "TableStatistics");
        }
    }
}
