using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    public partial class CreateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BarSum = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfSaleBar = table.Column<double>(type: "REAL", nullable: false),
                    SportSum = table.Column<double>(type: "REAL", nullable: false),
                    SportOfSaleSport = table.Column<double>(type: "REAL", nullable: false),
                    TableSum = table.Column<double>(type: "REAL", nullable: false),
                    PaymentType = table.Column<string>(type: "TEXT", nullable: false),
                    CardTime = table.Column<double>(type: "REAL", nullable: false),
                    TotalSum = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
