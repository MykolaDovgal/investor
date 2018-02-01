using Microsoft.EntityFrameworkCore.Migrations;

namespace Investor.Repository.Migrations
{
    public partial class IsBlogtocategoryBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlogPost",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlogPost",
                table: "Posts",
                nullable: true);
        }
    }
}
