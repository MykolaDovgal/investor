using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investor.Repository.Migrations
{
    public partial class newsblogsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropTable(
                name: "SliderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "PostEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryId",
                table: "PostEntity",
                newName: "IX_PostEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "PostEntity",
                newName: "IX_PostEntity_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "BlogEntityPostId",
                table: "PostTags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSide",
                table: "PostEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSlider",
                table: "PostEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryEntityCategoryId",
                table: "PostEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PostEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostEntity",
                table: "PostEntity",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_BlogEntityPostId",
                table: "PostTags",
                column: "BlogEntityPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEntity_CategoryEntityCategoryId",
                table: "PostEntity",
                column: "CategoryEntityCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostEntity_AspNetUsers_AuthorId",
                table: "PostEntity",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEntity_Categories_CategoryId",
                table: "PostEntity",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEntity_Categories_CategoryEntityCategoryId",
                table: "PostEntity",
                column: "CategoryEntityCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_PostEntity_BlogEntityPostId",
                table: "PostTags",
                column: "BlogEntityPostId",
                principalTable: "PostEntity",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_PostEntity_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "PostEntity",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostEntity_AspNetUsers_AuthorId",
                table: "PostEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEntity_Categories_CategoryId",
                table: "PostEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEntity_Categories_CategoryEntityCategoryId",
                table: "PostEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_PostEntity_BlogEntityPostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_PostEntity_PostId",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_BlogEntityPostId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostEntity",
                table: "PostEntity");

            migrationBuilder.DropIndex(
                name: "IX_PostEntity_CategoryEntityCategoryId",
                table: "PostEntity");

            migrationBuilder.DropColumn(
                name: "BlogEntityPostId",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "IsOnSide",
                table: "PostEntity");

            migrationBuilder.DropColumn(
                name: "IsOnSlider",
                table: "PostEntity");

            migrationBuilder.DropColumn(
                name: "CategoryEntityCategoryId",
                table: "PostEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PostEntity");

            migrationBuilder.RenameTable(
                name: "PostEntity",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_PostEntity_CategoryId",
                table: "Posts",
                newName: "IX_Posts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PostEntity_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.CreateTable(
                name: "SliderItems",
                columns: table => new
                {
                    SliderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsOnSide = table.Column<bool>(nullable: false),
                    IsOnSlider = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderItems", x => x.SliderItemId);
                    table.ForeignKey(
                        name: "FK_SliderItems_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SliderItems_PostId",
                table: "SliderItems",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
