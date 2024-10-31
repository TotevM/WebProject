using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditedWorkoutsAndExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Workouts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatedOn", "Difficulty", "IsDeleted", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { new Guid("1c6e0b2a-3b6a-4427-8df7-51d8a9f2a9a3"), new DateTime(2003, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 3, "Leg Extension" },
                    { new Guid("1e5b9a3c-2d8e-4c7d-9d3e-4d8f2c3e1b6f"), new DateTime(2018, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1, "Decline Bench Press" },
                    { new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2, "Pull-Up" },
                    { new Guid("2a8ed1d9-84d3-4fd4-83e2-2c4391f0b01b"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 0, "Tricep Extension" },
                    { new Guid("3e6c1f4b-0e5d-4f8d-8b2b-1a0e37dce9b7"), new DateTime(2003, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 3, "Calf Raise" },
                    { new Guid("3e9a5c5f-8d7e-4b2c-923b-27c4a6e2a6d7"), new DateTime(2003, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 3, "Step-Ups" },
                    { new Guid("4e8b7a3b-e5c1-4c73-95ab-27a05dcf2a31"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 2, "Seated Row" },
                    { new Guid("69b1df3e-1e34-44f3-8e3b-dca7eb9b2f3f"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1, "Dumbbell Fly" },
                    { new Guid("7e8c1e5b-0e6d-4b8d-8d2f-2a1e3c7dce8d"), new DateTime(2006, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 0, "Overhead Tricep Extension" },
                    { new Guid("8c3d6a7b-e1f2-4c3b-9d3e-0e3c4f5a1b2d"), new DateTime(2016, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1, "Close-Grip Bench Press" },
                    { new Guid("96d3e1b7-7806-4f54-bc58-5d8b9d8a7f1f"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 0, "Hammer Curl" },
                    { new Guid("9b8de205-3c91-47f8-a6bc-46a6d2c48238"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2, "T-Bar Row" },
                    { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 3, "Squat" },
                    { new Guid("b6a7ecb8-5e4e-4372-8d6d-f63b0c6e639e"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1, "Pec Deck" },
                    { new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 0, "Bicep Curl" },
                    { new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"), new DateTime(2003, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 3, "Lunges" },
                    { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1, "Push-Up" },
                    { new Guid("c9b4f5f1-1e3d-4a93-9d42-bb27a1b4b315"), new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 3, "Leg Press" },
                    { new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1, "Bench Press" },
                    { new Guid("ccf2748a-492e-496e-bd6b-8df2dc9b8f4a"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2, "Bent Over Row" },
                    { new Guid("d3e0b5f7-a1b5-4207-81b3-e0a5f6e0e8b5"), new DateTime(2003, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 3, "Reverse Lunges" },
                    { new Guid("d4f5b8b7-5638-4882-9254-07f5f35c09d6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 2, "Lat Pulldown" },
                    { new Guid("db8d4f5e-3f5f-4bfe-9b53-8171b4c77f8b"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, 2, "Deadlift" },
                    { new Guid("dbb7b1c4-72e8-4a37-91a7-fb97d4b4f0e3"), new DateTime(2003, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 3, "Bulgarian Split Squat" },
                    { new Guid("e2b1f3f7-8c1e-4b5f-9f2a-0e3c7d5b0d8d"), new DateTime(2016, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 0, "Skull Crusher" },
                    { new Guid("f2c3d8a4-b1e8-4d2f-9c3e-4d8f2e3c1b0d"), new DateTime(2016, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 0, "Cable Curl" },
                    { new Guid("fd3e8bc1-a4a6-4535-91f9-e4e68e0cde90"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 0, "Concentration Curl" },
                    { new Guid("fdcd4903-8d91-4091-91de-96b88b0a5f23"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1, "Incline Bench Press" },
                    { new Guid("ff5e9f1a-8f9f-4a8f-9081-d17b9e6fbe3c"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 2, "Back Extension" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("1c6e0b2a-3b6a-4427-8df7-51d8a9f2a9a3"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("1e5b9a3c-2d8e-4c7d-9d3e-4d8f2c3e1b6f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("2a8ed1d9-84d3-4fd4-83e2-2c4391f0b01b"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3e6c1f4b-0e5d-4f8d-8b2b-1a0e37dce9b7"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3e9a5c5f-8d7e-4b2c-923b-27c4a6e2a6d7"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("4e8b7a3b-e5c1-4c73-95ab-27a05dcf2a31"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("69b1df3e-1e34-44f3-8e3b-dca7eb9b2f3f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8c1e5b-0e6d-4b8d-8d2f-2a1e3c7dce8d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("8c3d6a7b-e1f2-4c3b-9d3e-0e3c4f5a1b2d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("96d3e1b7-7806-4f54-bc58-5d8b9d8a7f1f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9b8de205-3c91-47f8-a6bc-46a6d2c48238"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b6a7ecb8-5e4e-4372-8d6d-f63b0c6e639e"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("c9b4f5f1-1e3d-4a93-9d42-bb27a1b4b315"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ccf2748a-492e-496e-bd6b-8df2dc9b8f4a"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("d3e0b5f7-a1b5-4207-81b3-e0a5f6e0e8b5"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("d4f5b8b7-5638-4882-9254-07f5f35c09d6"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("db8d4f5e-3f5f-4bfe-9b53-8171b4c77f8b"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("dbb7b1c4-72e8-4a37-91a7-fb97d4b4f0e3"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("e2b1f3f7-8c1e-4b5f-9f2a-0e3c7d5b0d8d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("f2c3d8a4-b1e8-4d2f-9c3e-4d8f2e3c1b0d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("fd3e8bc1-a4a6-4535-91f9-e4e68e0cde90"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("fdcd4903-8d91-4091-91de-96b88b0a5f23"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ff5e9f1a-8f9f-4a8f-9081-d17b9e6fbe3c"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exercises");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Workouts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
