using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCorePersonelDepartman.Migrations
{
    public partial class addingmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birims",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birims", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirimID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK_Personels_Birims_BirimID",
                        column: x => x.BirimID,
                        principalTable: "Birims",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BirimID",
                table: "Personels",
                column: "BirimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Birims");
        }
    }
}
