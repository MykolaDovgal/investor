using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investor.Repository.Migrations
{
    public partial class addPostToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostEntity",
                table: "PostEntity");

            migrationBuilder.RenameTable(
                name: "PostEntity",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_PostEntity_CategoryEntityCategoryId",
                table: "Posts",
                newName: "IX_Posts_CategoryEntityCategoryId");

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
                name: "FK_Posts_Categories_CategoryEntityCategoryId",
                table: "Posts",
                column: "CategoryEntityCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_BlogEntityPostId",
                table: "PostTags",
                column: "BlogEntityPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryEntityCategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_BlogEntityPostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "PostEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryEntityCategoryId",
                table: "PostEntity",
                newName: "IX_PostEntity_CategoryEntityCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryId",
                table: "PostEntity",
                newName: "IX_PostEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "PostEntity",
                newName: "IX_PostEntity_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostEntity",
                table: "PostEntity",
                column: "PostId");

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
    }
}
