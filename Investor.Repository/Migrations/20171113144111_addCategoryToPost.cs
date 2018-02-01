using Microsoft.EntityFrameworkCore.Migrations;

namespace Investor.Repository.Migrations
{
    public partial class addCategoryToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryEntityCategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryEntityCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryEntityCategoryId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryEntityCategoryId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryEntityCategoryId",
                table: "Posts",
                column: "CategoryEntityCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryEntityCategoryId",
                table: "Posts",
                column: "CategoryEntityCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
