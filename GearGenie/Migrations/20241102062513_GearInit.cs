using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearGenie.Migrations
{
    /// <inheritdoc />
    public partial class GearInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerItems",
                columns: table => new
                {
                    PlayerCharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItems", x => new { x.ItemId, x.PlayerCharacterId });
                    table.ForeignKey(
                        name: "FK_PlayerItems_PlayerCharacters_PlayerCharacterId",
                        column: x => x.PlayerCharacterId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItems_PlayerCharacterId",
                table: "PlayerItems",
                column: "PlayerCharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerItems");

            migrationBuilder.DropTable(
                name: "PlayerCharacters");
        }
    }
}
