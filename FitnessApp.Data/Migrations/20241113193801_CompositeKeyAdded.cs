using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompositeKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDiets",
                table: "UsersDiets");

            migrationBuilder.DropIndex(
                name: "IX_UsersDiets_UserId",
                table: "UsersDiets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersDiets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDiets",
                table: "UsersDiets",
                columns: new[] { "UserId", "DietId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDiets",
                table: "UsersDiets");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UsersDiets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDiets",
                table: "UsersDiets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_UserId",
                table: "UsersDiets",
                column: "UserId");
        }
    }
}
