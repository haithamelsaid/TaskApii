using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapSubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapSubTypes_MapTypes_MapTypeId",
                        column: x => x.MapTypeId,
                        principalTable: "MapTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClusterRaduis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGeoFencing = table.Column<bool>(type: "bit", nullable: false),
                    TimeBuffer = table.Column<double>(type: "float", nullable: false),
                    LocationBuffer = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MapTypeId = table.Column<int>(type: "int", nullable: false),
                    MapSubTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_MapSubTypes_MapSubTypeId",
                        column: x => x.MapSubTypeId,
                        principalTable: "MapSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Maps_MapTypes_MapTypeId",
                        column: x => x.MapTypeId,
                        principalTable: "MapTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_MapSubTypeId",
                table: "Maps",
                column: "MapSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_MapTypeId",
                table: "Maps",
                column: "MapTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MapSubTypes_MapTypeId",
                table: "MapSubTypes",
                column: "MapTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "MapSubTypes");

            migrationBuilder.DropTable(
                name: "MapTypes");
        }
    }
}
