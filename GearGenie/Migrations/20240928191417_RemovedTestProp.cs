using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearGenie.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTestProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentCategoryElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: false),
                    DescriptionElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeaponCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeaponRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true),
                    ThrowRangeElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true),
                    DamageElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true),
                    TwoHandedElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true),
                    SpecialAttributeElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true),
                    ArmorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmorClassElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true),
                    StrengthMinimum = table.Column<int>(type: "int", nullable: true),
                    StealthDisadvantage = table.Column<bool>(type: "bit", nullable: true),
                    GearCategoryElement = table.Column<JsonElement>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EquipmentCategories");
        }
    }
}
