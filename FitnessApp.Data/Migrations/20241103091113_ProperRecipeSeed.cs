using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProperRecipeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"),
                column: "ImageUrl",
                value: "https://tasteforlife.com/sites/default/files/styles/laptop/public/diet-nutrition/special-diets/low-carb-diets-for-health-benefits/low-carb-diets-for-health-benefits.jpg?itok=saTbKWSP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Diets");
        }
    }
}
