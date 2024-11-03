using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DietSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserID",
                table: "Diets");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "CreatedOn", "Description", "Name", "UserID" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A well-balanced diet for healthy living.", "Balanced Diet", null },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ideal for muscle growth and recovery.", "High-Protein Diet", null },
                    { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A low-carb diet to promote weight loss.", "Low-Carb Diet", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserID",
                table: "Diets",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserID",
                table: "Diets");

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"));

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserID",
                table: "Diets",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
