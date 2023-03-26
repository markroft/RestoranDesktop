using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranDesktopApp.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyurtmalarMenu");

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
    }
}
