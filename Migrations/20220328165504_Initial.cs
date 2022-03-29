using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Solution.Migrations
{
#pragma warning disable CS1591
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Destinations",
          columns: table => new
          {
            DestinationId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Country = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Rating = table.Column<float>(type: "float", nullable: false),
            NumOfReviews = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Destinations", x => x.DestinationId);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Destinations");
    }
  }
#pragma warning restore CS1591
}
