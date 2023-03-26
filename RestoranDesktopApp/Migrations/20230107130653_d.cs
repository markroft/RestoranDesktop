using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestoranDesktopApp.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyurtmalarMenu");

            migrationBuilder.AddColumn<int>(
                name: "Menuid",
                table: "Buyurtmalar",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Taomlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomi = table.Column<string>(type: "text", nullable: false),
                    narxi = table.Column<int>(type: "integer", nullable: false),
                    Buyurtmalarid = table.Column<int>(type: "integer", nullable: true)
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
                name: "IX_Buyurtmalar_Menuid",
                table: "Buyurtmalar",
                column: "Menuid");

            migrationBuilder.CreateIndex(
                name: "IX_Taomlar_Buyurtmalarid",
                table: "Taomlar",
                column: "Buyurtmalarid");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyurtmalar_Menu_Menuid",
                table: "Buyurtmalar",
                column: "Menuid",
                principalTable: "Menu",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyurtmalar_Menu_Menuid",
                table: "Buyurtmalar");

            migrationBuilder.DropTable(
                name: "Taomlar");

            migrationBuilder.DropIndex(
                name: "IX_Buyurtmalar_Menuid",
                table: "Buyurtmalar");

            migrationBuilder.DropColumn(
                name: "Menuid",
                table: "Buyurtmalar");

            migrationBuilder.CreateTable(
                name: "BuyurtmalarMenu",
                columns: table => new
                {
                    Btaomlarid = table.Column<int>(type: "integer", nullable: false),
                    Buyurtmalarsid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyurtmalarMenu", x => new { x.Btaomlarid, x.Buyurtmalarsid });
                    table.ForeignKey(
                        name: "FK_BuyurtmalarMenu_Buyurtmalar_Buyurtmalarsid",
                        column: x => x.Buyurtmalarsid,
                        principalTable: "Buyurtmalar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyurtmalarMenu_Menu_Btaomlarid",
                        column: x => x.Btaomlarid,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyurtmalarMenu_Buyurtmalarsid",
                table: "BuyurtmalarMenu",
                column: "Buyurtmalarsid");
        }
    }
}
