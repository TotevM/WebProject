using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Halfseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") });
        }
    }
}
