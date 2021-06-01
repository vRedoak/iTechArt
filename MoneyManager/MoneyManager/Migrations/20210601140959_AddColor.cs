using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MoneyManager.Migrations
{
    public partial class AddColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: Int32.Parse("233D4D", System.Globalization.NumberStyles.HexNumber));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");
        }
    }
}
