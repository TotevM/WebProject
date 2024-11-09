using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Workouts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatedOn", "Name", "UserID" },
                values: new object[,]
                {
                    { new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8"), new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upper Body Strength", null },
                    { new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49"), new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Body Circuit", null },
                    { new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539"), new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Push-Pull Split", null },
                    { new Guid("cb33f115-f082-418a-afb4-02762aa8c235"), new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Core & Cardio", null },
                    { new Guid("f2095d49-635e-4617-a470-491008eb7621"), new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leg Day Challenge", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("cb33f115-f082-418a-afb4-02762aa8c235"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("f2095d49-635e-4617-a470-491008eb7621"));

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Workouts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
