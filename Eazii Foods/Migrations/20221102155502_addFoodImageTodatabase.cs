using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eazii_Foods.Migrations
{
    public partial class addFoodImageTodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Food",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Food");
        }
    }
}
