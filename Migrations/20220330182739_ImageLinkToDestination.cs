using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Solution.Migrations
{
#pragma warning disable CS1591
  public partial class ImageLinkToDestination : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "ImgLink",
          table: "Destinations",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "ImgLink",
          table: "Destinations");
    }
  }
#pragma warning restore CS1591
}
