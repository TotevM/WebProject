using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecipeUrlAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2211b081-9759-4ffb-865a-0636f462a78e"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ce6eda28-ad67-4837-b091-1a7c2279cd7d"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "Name", "Preparation", "UserID" },
                values: new object[,]
                {
                    { new Guid("0320bda7-0349-406a-86d0-61b170390d63"), null, "Eggs, salt", "Scrambled eggs", "Cook the eggs and put salt on them", null },
                    { new Guid("df00043f-dfe1-486e-a2e5-288d167b7a8d"), "https://sire-media-foxbg.fichub.com/24k_bg/custompage-main/302854.1024x576.jpg", "Eggs, salt", "Eye eggs", "Cook the eggs and put salt on them", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("0320bda7-0349-406a-86d0-61b170390d63"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("df00043f-dfe1-486e-a2e5-288d167b7a8d"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Ingredients", "Name", "Preparation", "UserID" },
                values: new object[,]
                {
                    { new Guid("2211b081-9759-4ffb-865a-0636f462a78e"), "Eggs, salt", "Eye eggs", "Cook the eggs and put salt on them", null },
                    { new Guid("ce6eda28-ad67-4837-b091-1a7c2279cd7d"), "Eggs, salt", "Scrambled eggs", "Cook the eggs and put salt on them", null }
                });
        }
    }
}
