using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Diets");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "WorkoutsExercises",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is exercise-workout relationship is active",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExerciseId",
                table: "WorkoutsExercises",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The Id of the exercise",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutId",
                table: "WorkoutsExercises",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The Id of the workout",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Workouts",
                type: "nvarchar(450)",
                nullable: true,
                comment: "The creator of the workout",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workouts",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                comment: "Name of the workout",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                comment: "The time the workout was created on",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Sets",
                table: "UsersWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 4,
                comment: "Number of sets",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Repetitions",
                table: "UsersWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 10,
                comment: "Number of repetitions",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersWorkouts",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The Id of the user",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutId",
                table: "UsersWorkouts",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The Id of the workout",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DietId",
                table: "UsersDiets",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The Id of the diet",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersDiets",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The Id of the diet creator",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true,
                comment: "The creator of the recipe",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Preparation",
                table: "Recipes",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                comment: "The preparation of the recipe",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "The name of the recipe",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "Recipes",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                comment: "The ingredients of the recipe",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The image URL of the recipe",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Goal",
                table: "Recipes",
                type: "int",
                nullable: false,
                comment: "The goal of the recipe",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Fats",
                table: "Recipes",
                type: "int",
                nullable: false,
                comment: "The fats of the recipe",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                comment: "The time the recipe was created on",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Carbohydrates",
                table: "Recipes",
                type: "int",
                nullable: false,
                comment: "The carbohydrates of the recipe",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Recipes",
                type: "int",
                nullable: false,
                comment: "The calories of the recipe",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Proteins",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The proteins of the recipe");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Progresses",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                comment: "The weight entered",
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Progresses",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The user who entered the progress data",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Progresses",
                type: "int",
                nullable: false,
                comment: "The height entered",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Progresses",
                type: "datetime2",
                nullable: false,
                comment: "The time the progress was entered",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                comment: "The name of the exercise",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "int",
                nullable: false,
                comment: "The muscle group the exercise targets",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Exercises",
                type: "bit",
                nullable: false,
                comment: "Is the exercise active or deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The image URL of the exercise",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Exercises",
                type: "int",
                nullable: false,
                comment: "The difficulty of the exercise",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                comment: "The time the exercise was created on",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "DietsRecipes",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The Id of the recipe",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DietId",
                table: "DietsRecipes",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The Id of the diet",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: true,
                comment: "The creator of the diet",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diets",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                comment: "Name of the diet",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The image URL of the diet",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fats",
                table: "Diets",
                type: "int",
                nullable: true,
                comment: "The fats of the diet",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Description of the diet",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diets",
                type: "datetime2",
                nullable: false,
                comment: "The time the diet was created on",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Carbohydrates",
                table: "Diets",
                type: "int",
                nullable: true,
                comment: "The carbohydrates of the diet",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Diets",
                type: "int",
                nullable: false,
                comment: "The calories of the diet",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Proteins",
                table: "Diets",
                type: "int",
                nullable: true,
                comment: "The proteins of the diet");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Username of the user",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                comment: "Last Name of the user",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                comment: "Is the account active",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                comment: "First Name of the user",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                comment: "Date of birth of the user",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("b9945d16-9964-4897-acba-2846f8730292"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("816b8eec-5ff7-408e-a903-55f509b97302"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("8e22c1d5-0c6e-47c7-bc25-559518fe4f24"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c670818c-d46f-440b-9332-0f0d01937887"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d2155f29-4a5a-4e71-a1ef-cb493b45bc4d"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"),
                column: "Proteins",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"),
                column: "Proteins",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Diets");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "WorkoutsExercises",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false,
                oldComment: "Is exercise-workout relationship is active");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExerciseId",
                table: "WorkoutsExercises",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The Id of the exercise");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutId",
                table: "WorkoutsExercises",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The Id of the workout");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Workouts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "The creator of the workout");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workouts",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldComment: "Name of the workout");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The time the workout was created on");

            migrationBuilder.AlterColumn<int>(
                name: "Sets",
                table: "UsersWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 4,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 4,
                oldComment: "Number of sets");

            migrationBuilder.AlterColumn<int>(
                name: "Repetitions",
                table: "UsersWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10,
                oldComment: "Number of repetitions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersWorkouts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The Id of the user");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutId",
                table: "UsersWorkouts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The Id of the workout");

            migrationBuilder.AlterColumn<Guid>(
                name: "DietId",
                table: "UsersDiets",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The Id of the diet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersDiets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The Id of the diet creator");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "The creator of the recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Preparation",
                table: "Recipes",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldComment: "The preparation of the recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldComment: "The name of the recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "Recipes",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldComment: "The ingredients of the recipe");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "The image URL of the recipe");

            migrationBuilder.AlterColumn<int>(
                name: "Goal",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The goal of the recipe");

            migrationBuilder.AlterColumn<int>(
                name: "Fats",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The fats of the recipe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The time the recipe was created on");

            migrationBuilder.AlterColumn<int>(
                name: "Carbohydrates",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The carbohydrates of the recipe");

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The calories of the recipe");

            migrationBuilder.AddColumn<int>(
                name: "Protein",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Progresses",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2,
                oldComment: "The weight entered");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Progresses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The user who entered the progress data");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Progresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The height entered");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Progresses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The time the progress was entered");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldComment: "The name of the exercise");

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The muscle group the exercise targets");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Exercises",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the exercise active or deleted");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "The image URL of the exercise");

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Exercises",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The difficulty of the exercise");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The time the exercise was created on");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "DietsRecipes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The Id of the recipe");

            migrationBuilder.AlterColumn<Guid>(
                name: "DietId",
                table: "DietsRecipes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The Id of the diet");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "The creator of the diet");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diets",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldComment: "Name of the diet");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "The image URL of the diet");

            migrationBuilder.AlterColumn<int>(
                name: "Fats",
                table: "Diets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "The fats of the diet");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Description of the diet");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The time the diet was created on");

            migrationBuilder.AlterColumn<int>(
                name: "Carbohydrates",
                table: "Diets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "The carbohydrates of the diet");

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Diets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The calories of the diet");

            migrationBuilder.AddColumn<int>(
                name: "Protein",
                table: "Diets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Username of the user");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true,
                oldComment: "Last Name of the user");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the account active");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true,
                oldComment: "First Name of the user");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of birth of the user");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("b9945d16-9964-4897-acba-2846f8730292"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"),
                column: "Protein",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"),
                column: "Protein",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"),
                column: "Protein",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"),
                column: "Protein",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"),
                column: "Protein",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"),
                column: "Protein",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"),
                column: "Protein",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1"),
                column: "Protein",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("816b8eec-5ff7-408e-a903-55f509b97302"),
                column: "Protein",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("8e22c1d5-0c6e-47c7-bc25-559518fe4f24"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281"),
                column: "Protein",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1"),
                column: "Protein",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"),
                column: "Protein",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e"),
                column: "Protein",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"),
                column: "Protein",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"),
                column: "Protein",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294"),
                column: "Protein",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"),
                column: "Protein",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"),
                column: "Protein",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021"),
                column: "Protein",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c670818c-d46f-440b-9332-0f0d01937887"),
                column: "Protein",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"),
                column: "Protein",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d2155f29-4a5a-4e71-a1ef-cb493b45bc4d"),
                column: "Protein",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"),
                column: "Protein",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"),
                column: "Protein",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921"),
                column: "Protein",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"),
                column: "Protein",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"),
                column: "Protein",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"),
                column: "Protein",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"),
                column: "Protein",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"),
                column: "Protein",
                value: 3);
        }
    }
}
