using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProperRecipeSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Carbohydrates",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fats",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Protein",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"),
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Protein" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"),
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Protein" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"),
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Protein" },
                values: new object[] { 0, 0, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Fats",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Diets");
        }
    }
}
