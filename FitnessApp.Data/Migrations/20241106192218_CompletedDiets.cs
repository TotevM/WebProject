using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompletedDiets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "ImageUrl",
                value: "https://image.cnbcfm.com/api/v1/image/107233399-1682954665721-dash-flexitarian-mediterranean-diet-to-stop-hypert-2022-02-14-13-50-46-utc.jpg?v=1682956537");

            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("816b8eec-5ff7-408e-a903-55f509b97302") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("816b8eec-5ff7-408e-a903-55f509b97302") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("2995c236-5b5d-42f9-89b5-15576256ee66") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("816b8eec-5ff7-408e-a903-55f509b97302") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("816b8eec-5ff7-408e-a903-55f509b97302") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("2995c236-5b5d-42f9-89b5-15576256ee66") });

            migrationBuilder.DeleteData(
                table: "DietsRecipes",
                keyColumns: new[] { "DietId", "RecipeId" },
                keyValues: new object[] { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "ImageUrl",
                value: "https://imgs.search.brave.com/W8_zgv8MUFPLIzugGECfKg3eilSWZNWVYu5m_RMcy7U/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9oaXBz/LmhlYXJzdGFwcHMu/Y29tL2htZy1wcm9k/L2ltYWdlcy9mb29k/cy1pdGVtcy1oaWdo/LWluLWhlYWx0aHkt/b21lZ2EtMy1mYXRz/LXJveWFsdHktZnJl/ZS1");

            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[] { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") });
        }
    }
}
