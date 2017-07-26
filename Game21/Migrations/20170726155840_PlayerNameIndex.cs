using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Game21.Migrations
{
    public partial class PlayerNameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Players");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");
            
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_Name",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
