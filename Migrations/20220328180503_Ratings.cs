using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Solution.Migrations
{
#pragma warning disable CS1591
  public partial class Ratings : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
          name: "Rating",
          table: "Destinations",
          newName: "AverageRating");

      migrationBuilder.CreateTable(
          name: "Reviews",
          columns: table => new
          {
            ReviewId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            DestinationId = table.Column<int>(type: "int", nullable: false),
            ReviewText = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Rating = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Reviews", x => x.ReviewId);
            table.ForeignKey(
                      name: "FK_Reviews_Destinations_DestinationId",
                      column: x => x.DestinationId,
                      principalTable: "Destinations",
                      principalColumn: "DestinationId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Reviews_DestinationId",
          table: "Reviews",
          column: "DestinationId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Reviews");

      migrationBuilder.RenameColumn(
          name: "AverageRating",
          table: "Destinations",
          newName: "Rating");
    }
  }
#pragma warning restore CS1591
}
