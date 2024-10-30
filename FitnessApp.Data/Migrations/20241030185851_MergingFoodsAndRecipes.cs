using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MergingFoodsAndRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietsFoods_Foods_FoodId",
                table: "DietsFoods");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietsFoods",
                table: "DietsFoods");

            migrationBuilder.DropIndex(
                name: "IX_DietsFoods_FoodId",
                table: "DietsFoods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "DietsFoods");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "DietsFoods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietsFoods",
                table: "DietsFoods",
                columns: new[] { "DietId", "RecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoods_RecipeId",
                table: "DietsFoods",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietsFoods_Recipes_RecipeId",
                table: "DietsFoods",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietsFoods_Recipes_RecipeId",
                table: "DietsFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietsFoods",
                table: "DietsFoods");

            migrationBuilder.DropIndex(
                name: "IX_DietsFoods_RecipeId",
                table: "DietsFoods");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "DietsFoods");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "DietsFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietsFoods",
                table: "DietsFoods",
                columns: new[] { "DietId", "FoodId" });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fats = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoods_FoodId",
                table: "DietsFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietsFoods_Foods_FoodId",
                table: "DietsFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
