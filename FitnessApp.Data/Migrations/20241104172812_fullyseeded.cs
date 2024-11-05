using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fullyseeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("ce451c31-e002-4e97-9140-dc81837b58a7") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("ce451c31-e002-4e97-9140-dc81837b58a7") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b") });
        }
    }
}
