using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investor.Repository.Migrations
{
    public partial class removePostTagId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Tags_TagId",
                table: "PostTags");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PostTags_PostTagId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "PostTagId",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PostTagEntity");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagId",
                table: "PostTagEntity",
                newName: "IX_PostTagEntity_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagEntity",
                table: "PostTagEntity",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagEntity_Posts_PostId",
                table: "PostTagEntity",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagEntity_Tags_TagId",
                table: "PostTagEntity",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagEntity_Posts_PostId",
                table: "PostTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTagEntity_Tags_TagId",
                table: "PostTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagEntity",
                table: "PostTagEntity");

            migrationBuilder.RenameTable(
                name: "PostTagEntity",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_PostTagEntity_TagId",
                table: "PostTags",
                newName: "IX_PostTags_TagId");

            migrationBuilder.AddColumn<int>(
                name: "PostTagId",
                table: "PostTags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PostTags_PostTagId",
                table: "PostTags",
                column: "PostTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Tags_TagId",
                table: "PostTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
