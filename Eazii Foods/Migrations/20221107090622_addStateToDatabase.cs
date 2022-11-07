using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eazii_Foods.Migrations
{
    public partial class addStateToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateId",
                table: "AspNetUsers");
        }
    }
}
