using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LoID);
                });

            migrationBuilder.CreateTable(
                name: "MainOffices",
                columns: table => new
                {
                    MoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainOffices", x => x.MoID);
                    table.ForeignKey(
                        name: "FK_MainOffices_Locations_LoId",
                        column: x => x.LoId,
                        principalTable: "Locations",
                        principalColumn: "LoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directorates",
                columns: table => new
                {
                    DrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorates", x => x.DrID);
                    table.ForeignKey(
                        name: "FK_Directorates_MainOffices_MoId",
                        column: x => x.MoId,
                        principalTable: "MainOffices",
                        principalColumn: "MoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BrID);
                    table.ForeignKey(
                        name: "FK_Branches_Directorates_DrId",
                        column: x => x.DrId,
                        principalTable: "Directorates",
                        principalColumn: "DrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DrId",
                table: "Branches",
                column: "DrId");

            migrationBuilder.CreateIndex(
                name: "IX_Directorates_MoId",
                table: "Directorates",
                column: "MoId");

            migrationBuilder.CreateIndex(
                name: "IX_MainOffices_LoId",
                table: "MainOffices",
                column: "LoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Directorates");

            migrationBuilder.DropTable(
                name: "MainOffices");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
