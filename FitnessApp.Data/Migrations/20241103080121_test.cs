using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietsRecipes_Recipes_RecipeId",
                table: "DietsRecipes");

            migrationBuilder.AddForeignKey(
                name: "FK_DietsRecipes_Recipes_RecipeId",
                table: "DietsRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietsRecipes_Recipes_RecipeId",
                table: "DietsRecipes");

            migrationBuilder.AddForeignKey(
                name: "FK_DietsRecipes_Recipes_RecipeId",
                table: "DietsRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
