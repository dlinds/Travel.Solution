using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Solution.Migrations
{
#pragma warning disable CS1591
  public partial class UserName : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "UserName",
          table: "Reviews",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "UserName",
          table: "Reviews");
    }
  }
#pragma warning restore CS1591
}
