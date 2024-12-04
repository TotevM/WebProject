using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDietDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Diets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                comment: "Description of the diet");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"),
                column: "Description",
                value: "Rich in fruits, vegetables, whole grains, and healthy fats.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"),
                column: "Description",
                value: "A well-balanced diet for healthy living.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"),
                column: "Description",
                value: "A low-carb diet to promote weight loss.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "Description",
                value: "Dietary Approaches to Stop Hypertension; focuses on lowering blood pressure.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("b9945d16-9964-4897-acba-2846f8730292"),
                column: "Description",
                value: "Ideal for muscle growth and recovery.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"),
                column: "Description",
                value: "High-fat, low-carb diet that aims to induce ketosis.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"),
                column: "Description",
                value: "A plant-based diet that excludes all animal products.");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"),
                column: "Description",
                value: "Focuses on whole foods similar to what might have been eaten in the Paleolithic era.");
        }
    }
}
