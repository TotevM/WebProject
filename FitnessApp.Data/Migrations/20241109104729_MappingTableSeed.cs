using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingTableSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutsExercises",
                columns: new[] { "ExerciseId", "WorkoutId" },
                values: new object[] { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") });
        }
    }
}
