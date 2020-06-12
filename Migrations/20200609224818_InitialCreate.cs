using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NLW.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Id");

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    whatsapp = table.Column<string>(nullable: false),
                    latidude = table.Column<decimal>(nullable: false),
                    longitude = table.Column<decimal>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    uf = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pointitems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    point_id = table.Column<int>(nullable: false),
                    Item_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pointitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_pointitems_items_Item_id",
                        column: x => x.Item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pointitems_points_point_id",
                        column: x => x.point_id,
                        principalTable: "points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "image", "title" },
                values: new object[,]
                {
                    { 1, "lampadas.svg", "Lâmpadas" },
                    { 2, "baterias.svg", "Pilhas e Baterias" },
                    { 3, "papeis-papelao.svg", "Papéis e Papelão" },
                    { 4, "eletronicos.svg", "Resíduos Eletrônicos" },
                    { 5, "organicos.svg", "Resíduos Orgânicos" },
                    { 6, "oleo.svg", "Óleo de Cozinha" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pointitems_Item_id",
                table: "pointitems",
                column: "Item_id");

            migrationBuilder.CreateIndex(
                name: "IX_pointitems_point_id",
                table: "pointitems",
                column: "point_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pointitems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropSequence(
                name: "Id");
        }
    }
}
