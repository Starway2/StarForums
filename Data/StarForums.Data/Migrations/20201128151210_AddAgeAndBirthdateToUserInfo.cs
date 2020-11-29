using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarForums.Data.Migrations
{
    public partial class AddAgeAndBirthdateToUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Infos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Infos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Infos");
        }
    }
}
