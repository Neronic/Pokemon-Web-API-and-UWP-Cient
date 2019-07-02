using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonWebApi.Data.PokemonMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pokemon");

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "Pokemon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "Pokemon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 20, nullable: false),
                    TypeOne = table.Column<string>(maxLength: 20, nullable: true),
                    TypeTwo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                schema: "Pokemon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteName = table.Column<string>(maxLength: 30, nullable: false),
                    RegionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Route_Region_RegionID",
                        column: x => x.RegionID,
                        principalSchema: "Pokemon",
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                schema: "Pokemon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    TypesID = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pokemon_Route_RouteID",
                        column: x => x.RouteID,
                        principalSchema: "Pokemon",
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Types_TypesID",
                        column: x => x.TypesID,
                        principalSchema: "Pokemon",
                        principalTable: "Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_Number",
                schema: "Pokemon",
                table: "Pokemon",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_RouteID",
                schema: "Pokemon",
                table: "Pokemon",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_TypesID",
                schema: "Pokemon",
                table: "Pokemon",
                column: "TypesID");

            migrationBuilder.CreateIndex(
                name: "IX_Region_RegionName",
                schema: "Pokemon",
                table: "Region",
                column: "RegionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Route_RegionID",
                schema: "Pokemon",
                table: "Route",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_RouteName",
                schema: "Pokemon",
                table: "Route",
                column: "RouteName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_TypeName",
                schema: "Pokemon",
                table: "Types",
                column: "TypeName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon",
                schema: "Pokemon");

            migrationBuilder.DropTable(
                name: "Route",
                schema: "Pokemon");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "Pokemon");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "Pokemon");
        }
    }
}
