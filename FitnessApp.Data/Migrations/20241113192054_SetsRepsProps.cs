using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetsRepsProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "WorkoutsExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "WorkoutsExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("2a8ed1d9-84d3-4fd4-83e2-2c4391f0b01b"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("d4f5b8b7-5638-4882-9254-07f5f35c09d6"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("3e9a5c5f-8d7e-4b2c-923b-27c4a6e2a6d7"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("ff5e9f1a-8f9f-4a8f-9081-d17b9e6fbe3c"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("3e6c1f4b-0e5d-4f8d-8b2b-1a0e37dce9b7"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("c9b4f5f1-1e3d-4a93-9d42-bb27a1b4b315"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "WorkoutsExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { new Guid("dbb7b1c4-72e8-4a37-91a7-fb97d4b4f0e3"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                columns: new[] { "Repetitions", "Sets" },
                values: new object[] { 10, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "WorkoutsExercises");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "WorkoutsExercises");
        }
    }
}
