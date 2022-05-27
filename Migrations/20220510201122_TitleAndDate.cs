using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Solution.Migrations
{
    public partial class TitleAndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "Reviews",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReviewTitle",
                table: "Reviews",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewTitle",
                table: "Reviews");
        }
    }
}
