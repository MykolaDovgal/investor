using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investor.Repository.Migrations
{
    public partial class authorVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_BlogEntityPostId",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_BlogEntityPostId",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "BlogEntityPostId",
                table: "PostTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogEntityPostId",
                table: "PostTags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_BlogEntityPostId",
                table: "PostTags",
                column: "BlogEntityPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_BlogEntityPostId",
                table: "PostTags",
                column: "BlogEntityPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
