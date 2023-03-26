using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestoranDesktopApp.Migrations
{
    /// <inheritdoc />
    public partial class r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taomlar");

            migrationBuilder.AddColumn<int>(
                name: "Buyurtmalarid",
                table: "Menu",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Buyurtmalarid",
                table: "Menu",
                column: "Buyurtmalarid");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Buyurtmalar_Buyurtmalarid",
                table: "Menu",
                column: "Buyurtmalarid",
                principalTable: "Buyurtmalar",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Buyurtmalar_Buyurtmalarid",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_Buyurtmalarid",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Buyurtmalarid",
                table: "Menu");

            migrationBuilder.CreateTable(
                name: "Taomlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Buyurtmalarid = table.Column<int>(type: "integer", nullable: true),
                    narxi = table.Column<int>(type: "integer", nullable: false),
                    nomi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taomlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Taomlar_Buyurtmalar_Buyurtmalarid",
                        column: x => x.Buyurtmalarid,
                        principalTable: "Buyurtmalar",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taomlar_Buyurtmalarid",
                table: "Taomlar",
                column: "Buyurtmalarid");
        }
    }
}
