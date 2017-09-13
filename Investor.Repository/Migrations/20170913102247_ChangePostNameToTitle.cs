using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investor.Repository.Migrations
{
    public partial class ChangePostNameToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Posts",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "SliderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SliderItems_PostId",
                table: "SliderItems",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_SliderItems_Posts_PostId",
                table: "SliderItems",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderItems_Posts_PostId",
                table: "SliderItems");

            migrationBuilder.DropIndex(
                name: "IX_SliderItems_PostId",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "SliderItems");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "Name");
        }
    }
}
