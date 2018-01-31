using Microsoft.EntityFrameworkCore.Migrations;

namespace Investor.Repository.Migrations
{
    public partial class addCropPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerializedCropPoints",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerializedCropPoints",
                table: "AspNetUsers");
        }
    }
}
