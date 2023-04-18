using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snd_API.Migrations
{
    /// <inheritdoc />
    public partial class ItemChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasePrice",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStock",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastSoldPrice",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastSoldTime",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceMax",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceMin",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTrades",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastSoldPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastSoldTime",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PriceMax",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PriceMin",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TotalTrades",
                table: "Items");
        }
    }
}
