using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingtableSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("b9945d16-9964-4897-acba-2846f8730292"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"),
                column: "CreatedOn",
                value: new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("b9945d16-9964-4897-acba-2846f8730292"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") },
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021") },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") },
                    { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a") },
                    { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e") },
                    { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") }
                });
        }
    }
}
