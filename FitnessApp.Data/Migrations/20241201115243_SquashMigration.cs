using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Username of the user"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is the account deleted or not"),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false, comment: "The name of the exercise"),
                    Difficulty = table.Column<int>(type: "int", nullable: false, comment: "The difficulty of the exercise"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time the exercise was created on"),
                    MuscleGroup = table.Column<int>(type: "int", nullable: false, comment: "The muscle group the exercise targets"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The image URL of the exercise"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is the exercise deleted or not")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false, comment: "Name of the diet"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Description of the diet"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "The creator of the diet"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time the diet was created on"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The image URL of the diet"),
                    Calories = table.Column<int>(type: "int", nullable: false, comment: "The calories of the diet"),
                    Proteins = table.Column<int>(type: "int", nullable: true, comment: "The proteins of the diet"),
                    Carbohydrates = table.Column<int>(type: "int", nullable: true, comment: "The carbohydrates of the diet"),
                    Fats = table.Column<int>(type: "int", nullable: true, comment: "The fats of the diet")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time the progress was entered"),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false, comment: "The weight entered"),
                    Height = table.Column<int>(type: "int", nullable: false, comment: "The height entered"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The user who entered the progress data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progresses_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "The name of the recipe"),
                    Ingredients = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "The ingredients of the recipe"),
                    Preparation = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "The preparation of the recipe"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The image URL of the recipe"),
                    Goal = table.Column<int>(type: "int", nullable: false, comment: "The goal of the recipe"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time the recipe was created on"),
                    Calories = table.Column<int>(type: "int", nullable: false, comment: "The calories of the recipe"),
                    Proteins = table.Column<int>(type: "int", nullable: false, comment: "The proteins of the recipe"),
                    Carbohydrates = table.Column<int>(type: "int", nullable: false, comment: "The carbohydrates of the recipe"),
                    Fats = table.Column<int>(type: "int", nullable: false, comment: "The fats of the recipe"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "The creator of the recipe"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false, comment: "Name of the workout"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time the workout was created on"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "The creator of the workout")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersDiets",
                columns: table => new
                {
                    DietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Id of the diet"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Id of the diet creator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDiets", x => new { x.UserId, x.DietId });
                    table.ForeignKey(
                        name: "FK_UsersDiets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietsRecipes",
                columns: table => new
                {
                    DietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Id of the diet"),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Id of the recipe")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsRecipes", x => new { x.DietId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_DietsRecipes_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietsRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersWorkouts",
                columns: table => new
                {
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Id of the workout"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Id of the user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersWorkouts", x => new { x.WorkoutId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersWorkouts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutsExercises",
                columns: table => new
                {
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Id of the workout"),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Id of the exercise"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Does exercise-workout relationship exist"),
                    Sets = table.Column<int>(type: "int", nullable: false, defaultValue: 4, comment: "Number of sets"),
                    Repetitions = table.Column<int>(type: "int", nullable: false, defaultValue: 10, comment: "Number of repetitions")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutsExercises", x => new { x.WorkoutId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_WorkoutsExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutsExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "Calories", "Carbohydrates", "CreatedOn", "Description", "Fats", "ImageUrl", "Name", "Proteins", "UserID" },
                values: new object[,]
                {
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rich in fruits, vegetables, whole grains, and healthy fats.", 0, "https://imgs.search.brave.com/XMqYsLggsYc1O09i-aEGhJO-TlIABgiyisJeNCe1RzE/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/aGVhcnQub3JnLy0v/bWVkaWEvQUhBL0g0/R00vQXJ0aWNsZS1J/bWFnZXMvTWVkaXRl/cnJhbmVhbl9EaWV0/LmpwZw", "Mediterranean Diet", 0, null },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A well-balanced diet for healthy living.", 0, "https://imgs.search.brave.com/s8CFdPvLm2v8QBJZdmM9JTjyexe9YWX3kQMEu26T0FI/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/cHJlbWl1bS1waG90/by93ZWxsLWJhbGFu/Y2VkLXBsYXRlLWZv/b2QtZmVhdHVyaW5n/LWxlYW4tcHJvdGVp/bnMtaGVhbHRoeS1l/YXRpbmctY2hvaWNl/c184OTM1NzEtNjY1/MDIuanBnP3NlbXQ9/YWlzX2h5YnJpZA", "Balanced Diet", 0, null },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A low-carb diet to promote weight loss.", 0, "https://tasteforlife.com/sites/default/files/styles/laptop/public/diet-nutrition/special-diets/low-carb-diets-for-health-benefits/low-carb-diets-for-health-benefits.jpg?itok=saTbKWSP", "Low-Carb Diet", 0, null },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dietary Approaches to Stop Hypertension; focuses on lowering blood pressure.", 0, "https://image.cnbcfm.com/api/v1/image/107233399-1682954665721-dash-flexitarian-mediterranean-diet-to-stop-hypert-2022-02-14-13-50-46-utc.jpg?v=1682956537", "DASH Diet", 0, null },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ideal for muscle growth and recovery.", 0, "https://imgs.search.brave.com/nFLS8O8iqyEsTxAc25VNTBCwWxqg_TGi_X-RsVNVqck/rs:fit:860:0:0:0/g:ce/aHR0cDovL2NvbnRl/bnQuaGVhbHRoLmhh/cnZhcmQuZWR1L3dw/LWNvbnRlbnQvdXBs/b2Fkcy8yMDI0LzAx/LzI4ZThlNDY0LWY1/NWUtNGIzMi05YmFi/LWRjOTkwZDhjYzky/Ny5qcGc", "High-Protein Diet", 0, null },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-fat, low-carb diet that aims to induce ketosis.", 0, "https://imgs.search.brave.com/La-R_B0imoy5SP6j0f1AFv1eM1NgGMmWg5yN9IczNEo/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTEz/Mzc5NDIyMS9waG90/by9oZWFsdGh5LWtl/dG8tYnJlYWtmYXN0/LWVnZy1hdm9jYWRv/LWNoZWVzZS1iYWNv/bi5qcGc_cz02MTJ4/NjEyJnc9MCZrPTIw/JmM9eVV6QnJJaUxO/a2NiOHFhVXRldEJO/LVVCQXQ1OGtVWjN6/amlkZ2UtR253OD0", "Keto Diet", 0, null },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A plant-based diet that excludes all animal products.", 0, "https://imgs.search.brave.com/xOEfQ19UaCLOKXzo-5Jbb4nLcKwO9UbBo5wewTvTJXw/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMuaW1tZWRpYXRl/LmNvLnVrL3Byb2R1/Y3Rpb24vdm9sYXRp/bGUvc2l0ZXMvMzAv/MjAyNC8wNi9IZWFs/dGh5LXZlZ2FuNzAw/LWU2YzJiNWUuanBn/P3F1YWxpdHk9OTAm/Zml0PTcwMCwzNTA", "Vegan Diet", 0, null },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), 0, 0, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Focuses on whole foods similar to what might have been eaten in the Paleolithic era.", 0, "https://imgs.search.brave.com/3oOdIC1IaTHXOsjmkwIhQCtX9QNDaBkJUo_hAxv1Xjg/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9hc3Nl/dHMuY2xldmVsYW5k/Y2xpbmljLm9yZy90/cmFuc2Zvcm0vTGFy/Z2VGZWF0dXJlSW1h/Z2UvZWJiZDhjMGYt/OTcwOS00YjFkLWJk/OTktZTNlMzE1MWYw/ZTNhL1BhbGVvLURp/ZXQtMTMwMTU2NTM3/NS03NzB4NTMzLTFf/anBn", "Paleo Diet", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatedOn", "Difficulty", "ImageUrl", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { new Guid("1c6e0b2a-3b6a-4427-8df7-51d8a9f2a9a3"), new DateTime(2003, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://physiotutors.com/wp-content/uploads/2022/01/Seated-Leg-Extension-featured.jpg", 3, "Leg Extension" },
                    { new Guid("1e5b9a3c-2d8e-4c7d-9d3e-4d8f2c3e1b6f"), new DateTime(2018, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://i.ytimg.com/vi/oIgci8aNsG0/maxresdefault.jpg", 1, "Decline Bench Press" },
                    { new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://rockrun.com/cdn/shop/articles/859664_1600x.jpg?v=1585560306", 2, "Pull-Up" },
                    { new Guid("2a8ed1d9-84d3-4fd4-83e2-2c4391f0b01b"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://www.trainheroic.com/wp-content/uploads/2023/02/AdobeStock_271990601-TH-jpg.webp", 0, "Tricep Extension" },
                    { new Guid("3e6c1f4b-0e5d-4f8d-8b2b-1a0e37dce9b7"), new DateTime(2003, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://www.jefit.com/images/exercises/960_590/4944.jpg", 3, "Calf Raise" },
                    { new Guid("3e9a5c5f-8d7e-4b2c-923b-27c4a6e2a6d7"), new DateTime(2003, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://media1.popsugar-assets.com/files/thumbor/wt7_DSw2I9cf_vui75Wo9K_nu_k=/fit-in/792x792/filters:format_auto():quality(70):extract_cover():upscale()/2024/03/13/886/n/1922729/tmp_rwtOqh_ab899a86a9ca6d73_PS23_Fitness_Workout_07_Move_08_Step_Up_v2.gif", 3, "Step-Ups" },
                    { new Guid("4e8b7a3b-e5c1-4c73-95ab-27a05dcf2a31"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://cdn.muscleandstrength.com/sites/default/files/seated-cable-row.jpg", 2, "Seated Row" },
                    { new Guid("69b1df3e-1e34-44f3-8e3b-dca7eb9b2f3f"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://cdn.muscleandstrength.com/sites/default/files/dumbbell-fly.jpg", 1, "Dumbbell Fly" },
                    { new Guid("7e8c1e5b-0e6d-4b8d-8d2f-2a1e3c7dce8d"), new DateTime(2006, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://cdn.muscleandstrength.com/sites/default/files/seated-overhead-dumbbell-tricep-extension_0.jpg", 0, "Overhead Tricep Extension" },
                    { new Guid("8c3d6a7b-e1f2-4c3b-9d3e-0e3c4f5a1b2d"), new DateTime(2016, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://www.dmoose.com/cdn/shop/articles/1_155d781f-a698-40e7-bdb6-f0de019f9b89.jpg?v=1648738774", 1, "Close-Grip Bench Press" },
                    { new Guid("96d3e1b7-7806-4f54-bc58-5d8b9d8a7f1f"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://hips.hearstapps.com/hmg-prod/images/hammer-curls-1581441441.jpg?crop=0.668xw:1.00xh", 0, "Hammer Curl" },
                    { new Guid("9b8de205-3c91-47f8-a6bc-46a6d2c48238"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://cdn.muscleandstrength.com/sites/default/files/t-bar-row.jpg", 2, "T-Bar Row" },
                    { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://fitnessvolt.com/wp-content/uploads/2021/09/Female-bodyweight-squat-750x549.jpg", 3, "Squat" },
                    { new Guid("b6a7ecb8-5e4e-4372-8d6d-f63b0c6e639e"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://www.newbodyplan.co.uk/wp-content/uploads/2022/01/pec-deck-chest-machine-flye-pectorals-man-gym-weight-training.jpg", 1, "Pec Deck" },
                    { new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://cdn.muscleandstrength.com/sites/default/files/field/feature-image/workout/guns-a-blazing-feature.jpg", 0, "Bicep Curl" },
                    { new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"), new DateTime(2003, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://images.healthshots.com/healthshots/en/uploads/2024/05/02174153/Lunges.jpg", 3, "Lunges" },
                    { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://cdn.mos.cms.futurecdn.net/9ghCpUY6JaLtStkZkeH73T-1200-80.jpg", 1, "Push-Up" },
                    { new Guid("c9b4f5f1-1e3d-4a93-9d42-bb27a1b4b315"), new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://ironbullstrength.com/cdn/shop/articles/leg_press_knee_pain.webp?v=1695829075", 3, "Leg Press" },
                    { new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://www.barbellmedicine.com/wp-content/uploads/2023/10/The-Bench-Press.jpg", 1, "Bench Press" },
                    { new Guid("ccf2748a-492e-496e-bd6b-8df2dc9b8f4a"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://d1lcvt77zgh63s.cloudfront.net/wp-content/uploads/2023/09/barbell-bent-over-row.jpg", 2, "Bent Over Row" },
                    { new Guid("d3e0b5f7-a1b5-4207-81b3-e0a5f6e0e8b5"), new DateTime(2003, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://media.self.com/photos/5c5b6d8f8f8b702d129df281/master/pass/woman-lunging-gym.jpg", 3, "Reverse Lunges" },
                    { new Guid("d4f5b8b7-5638-4882-9254-07f5f35c09d6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://cdn.muscleandstrength.com/sites/default/files/lat-pull-down.jpg", 2, "Lat Pulldown" },
                    { new Guid("db8d4f5e-3f5f-4bfe-9b53-8171b4c77f8b"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://uk.gymreapers.com/cdn/shop/articles/wearing_a_lifting_belt_for_deadlifts.png?v=1675261258&width=1500", 2, "Deadlift" },
                    { new Guid("dbb7b1c4-72e8-4a37-91a7-fb97d4b4f0e3"), new DateTime(2003, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://www.tonal.com/wp-content/uploads/2024/01/Bulgarian-Split-Squat-Hero.jpg", 3, "Bulgarian Split Squat" },
                    { new Guid("e2b1f3f7-8c1e-4b5f-9f2a-0e3c7d5b0d8d"), new DateTime(2016, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://mirafit.co.uk/wp/wp-content/uploads/2023/12/skull-crusher-using-Mirafit-EZ-Curl-Bar-1024x683.jpg", 0, "Skull Crusher" },
                    { new Guid("f2c3d8a4-b1e8-4d2f-9c3e-4d8f2e3c1b0d"), new DateTime(2016, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://www.borntough.com/cdn/shop/articles/Best_Biceps_Cable_Curls_Variations_and_Workouts.jpg?v=1655822555", 0, "Cable Curl" },
                    { new Guid("fd3e8bc1-a4a6-4535-91f9-e4e68e0cde90"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://cdn.muscleandstrength.com/sites/default/files/seated-concentration-curl.jpg", 0, "Concentration Curl" },
                    { new Guid("fdcd4903-8d91-4091-91de-96b88b0a5f23"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://cdn.muscleandstrength.com/sites/default/files/incline-bench-press.jpg", 1, "Incline Bench Press" },
                    { new Guid("ff5e9f1a-8f9f-4a8f-9081-d17b9e6fbe3c"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://steelsupplements.com/cdn/shop/articles/shutterstock_1705063531_1000x.jpg?v=1642058677", 2, "Back Extension" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Carbohydrates", "CreatedOn", "Fats", "Goal", "ImageUrl", "Ingredients", "Name", "Preparation", "Proteins", "UserID" },
                values: new object[,]
                {
                    { new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"), 350, 30, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 2, "https://www.allrecipes.com/thmb/8NccFzsaq0_OZPDKmf7Yee-aG78=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/AvocadoToastwithEggFranceC4x3-bb87e3bbf1944657b7db35f1383fabdb.jpg", "Bread, avocado, salt, pepper, lemon", "Avocado Toast", "Toast the bread to your desired level of crispiness in a toaster or oven. Meanwhile, in a bowl, mash the avocado until smooth, seasoning it with a pinch of salt, freshly ground black pepper, and a squeeze of lemon juice for a bit of tanginess. Once the bread is toasted, generously spread the mashed avocado over each slice. For added texture and flavor, you can layer optional toppings such as sliced tomatoes, thinly sliced radishes, or a poached egg on top. Serve immediately to enjoy the fresh flavors.", 10, null },
                    { new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"), 350, 45, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, "https://www.whollytasteful.com/wp-content/uploads/2022/09/protein-pancakes-with-oats-featured.jpg", "Oats, banana, protein powder, eggs", "Protein Pancakes", "In a blender, combine the oats, banana, protein powder, and eggs. Blend until the mixture is smooth and free of lumps. Heat a non-stick pan over medium heat and lightly coat it with cooking spray. Pour a small amount of the batter onto the pan and cook for 2-3 minutes until bubbles appear on the surface. Flip the pancake and cook for an additional 2 minutes on the other side. Serve warm, topped with fresh berries or a drizzle of honey for added flavor.", 25, null },
                    { new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"), 350, 30, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0, "https://thebeanbites.com/wp-content/uploads/2020/03/Instant-Pot-Stuffed-Peppers-10-720x540.jpg", "Bell peppers, ground turkey, quinoa, cheese", "Stuffed Bell Peppers", "Preheat the oven to 375°F (190°C). Prepare the bell peppers by cutting off the tops and removing the seeds and membranes. In a mixing bowl, combine cooked quinoa, browned ground turkey, and shredded cheese. Season the mixture with salt and pepper to taste. Stuff each bell pepper with the quinoa and turkey mixture, packing it tightly. Arrange the stuffed peppers upright in a baking dish, cover the dish with foil, and bake for 30 minutes. Remove the foil and bake for an additional 10 minutes until the peppers are tender and the cheese is melted and golden. Serve hot.", 25, null },
                    { new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"), 300, 40, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, "https://assets.bonappetit.com/photos/5a05c9df3388d32a6ed54e97/1:1/w_2560%2Cc_limit/curried-lentil-tomato-and-coconut-soup.jpg", "Lentils, coconut milk, curry powder, vegetables", "Coconut Curry Lentil Soup", "In a large pot, heat a drizzle of oil over medium heat, then add your choice of chopped vegetables (such as onions, carrots, and bell peppers). Sauté until the vegetables are softened and fragrant. Stir in the lentils, making sure they are well mixed with the vegetables. Pour in the coconut milk, curry powder, and enough water or vegetable broth to cover the ingredients, then bring the mixture to a gentle boil. Once boiling, reduce the heat to a simmer and cook for 20-25 minutes, stirring occasionally, until the lentils are tender and the soup has thickened. Season with salt and pepper to taste, and garnish with fresh cilantro or lime juice before serving for extra flavor.", 15, null },
                    { new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"), 200, 5, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, "https://tealnotes.com/wp-content/uploads/2023/05/Featured-Image-46-800x530.png", "Eggs, salt, bell pepper, spinach", "Scrambled Eggs with Veggies", "Crack the eggs into a bowl, add a pinch of salt, and whisk until smooth. Heat a small amount of olive oil in a non-stick skillet over medium heat. Add diced bell pepper and cook for 2-3 minutes until softened. Add the spinach and cook until wilted, about 1 minute. Pour the eggs into the pan and gently stir with a spatula, folding the eggs over themselves until just set. Remove from heat while the eggs are still slightly soft. Serve hot, garnished with fresh herbs if desired.", 12, null },
                    { new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"), 200, 10, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://www.sweetashoney.co/wp-content/uploads/Zucchini-Noodles-With-Pesto-2-1.jpg", "Zucchini, pesto, cherry tomatoes, olive oil", "Zucchini Noodles with Pesto", "Using a spiralizer or a julienne peeler, prepare the zucchini noodles and set them aside. Heat a drizzle of olive oil in a large skillet over medium heat, then add the zucchini noodles. Sauté them for about 2-3 minutes, stirring gently to ensure even cooking, until they are slightly softened but still retain a bit of crunch. Add the pesto sauce and toss to coat the noodles thoroughly. Next, add halved cherry tomatoes and cook for an additional 2 minutes, allowing the tomatoes to warm through. Serve immediately, optionally garnishing with grated Parmesan or fresh basil for added flavor.", 5, null },
                    { new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"), 400, 8, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 1, "https://saltpepperskillet.com/wp-content/uploads/oven-baked-salmon-on-sheet-pan-horizontal-1.jpg", "Salmon fillet, lemon, herbs, asparagus", "Baked Salmon", "Preheat the oven to 400°F (200°C). Place the salmon fillet on a baking sheet lined with parchment paper. Squeeze fresh lemon juice over the top and sprinkle with herbs like dill or parsley. Arrange asparagus around the salmon and drizzle with olive oil. Bake for about 15-20 minutes until the salmon is cooked through and flakes easily with a fork. Serve warm with a side of your choice.", 40, null },
                    { new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"), 350, 30, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0, "https://onebalancedlife.com/wp-content/uploads/2020/08/Breakfast-Wrap-scaled-720x720.jpg", "Eggs, spinach, whole wheat wrap, cheese", "Egg and Spinach Breakfast Wrap", "Begin by whisking the eggs in a bowl until the yolks and whites are fully blended. In a skillet, heat a little oil or butter over medium heat, then add the spinach. Cook, stirring occasionally, until the spinach is wilted and softened, about 2-3 minutes. Pour the beaten eggs into the skillet with the spinach, and cook gently, stirring occasionally to scramble, until the eggs are fully cooked but still soft. Once the egg and spinach mixture is ready, remove from heat. Place a whole wheat wrap on a flat surface, and spoon the egg and spinach mixture onto the center. Sprinkle with cheese of your choice, such as cheddar or feta. Carefully fold the sides of the wrap over the filling and roll it tightly to form a wrap. Serve warm, perfect for a nutritious breakfast on the go.", 25, null },
                    { new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"), 300, 30, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 0, "https://www.nutritiousdeliciousness.com/wp-content/uploads/2024/02/Asian-Shrimp-Tacos1.jpg", "Shrimp, corn tortillas, cabbage, lime", "Shrimp Tacos", "Begin by seasoning the shrimp with a pinch of salt and pepper, ensuring they are evenly coated. In a skillet over medium heat, add a small amount of oil and cook the shrimp until they are opaque and pink, about 2-3 minutes per side. In a separate pan, warm the corn tortillas until they are pliable and lightly toasted. To assemble the tacos, place a few shrimp on each tortilla, add a generous handful of shredded cabbage for crunch, and finish with a squeeze of fresh lime juice. Serve immediately, optionally topping with sliced avocado, salsa, or chopped cilantro for additional flavor.", 25, null },
                    { new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"), 300, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 2, "https://heavenlyhomecooking.com/wp-content/uploads/2021/04/Vegetable-Omelette-Recipe-Featured-1.jpg", "Eggs, bell peppers, cheese, spinach", "Veggie Omelette", "Whisk the eggs in a bowl and season with salt and pepper. Heat a non-stick skillet over medium heat and add a little oil. Pour in the eggs and let them cook for about 1-2 minutes until the edges start to set. Add diced bell peppers and cheese on one half of the omelette. Carefully fold the other half over the filling and cook for another minute until the cheese melts and the eggs are fully cooked. Serve hot with a side of toast or fresh fruit.", 18, null },
                    { new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1"), 450, 55, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, "https://img.buzzfeed.com/thumbnailer-prod-us-east-1/video-api/assets/13385.jpg", "Chicken breast, brown rice, broccoli", "Chicken and Rice", "Start by seasoning the chicken breast with salt, pepper, and your favorite spices. Heat a grill pan over medium heat and cook the chicken for about 5-6 minutes on each side, or until fully cooked. Meanwhile, bring a pot of water to a boil and add the brown rice, cooking for about 30-35 minutes until tender. Steam the broccoli for 5-7 minutes, until it is bright green and slightly tender. Serve the grilled chicken over the rice with a side of steamed broccoli. Optionally, drizzle with a little olive oil or lemon juice.", 35, null },
                    { new Guid("816b8eec-5ff7-408e-a903-55f509b97302"), 450, 10, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2, "https://www.lecremedelacrumb.com/wp-content/uploads/2019/04/sheet-pan-salmon-potatoes-asparagus-1-3.jpg", "Salmon fillet, asparagus, olive oil, lemon", "Baked Salmon with Asparagus", "Preheat the oven to 400°F (200°C). Arrange the salmon fillets and trimmed asparagus spears on a baking sheet lined with parchment paper. Drizzle with olive oil and squeeze fresh lemon juice over the salmon and asparagus. Sprinkle with salt and pepper to taste. Place the baking sheet in the oven and bake for 15-20 minutes, or until the salmon is cooked through and flakes easily with a fork, and the asparagus is tender-crisp. Serve hot with additional lemon wedges if desired.", 40, null },
                    { new Guid("8e22c1d5-0c6e-47c7-bc25-559518fe4f24"), 200, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, "https://littlespoonfarm.com/wp-content/uploads/2021/08/tuna-salad-recipe-card.jpg", "Canned tuna, mayo, celery, lettuce", "Tuna Salad", "In a medium-sized bowl, mix drained canned tuna with a tablespoon of mayo and finely diced celery until well combined. Season the mixture with salt and pepper to taste, adjusting the seasoning as needed. For an added layer of flavor, you might sprinkle in a dash of lemon juice. Once mixed, place a generous scoop of the tuna mixture onto a bed of fresh lettuce leaves on a plate. For extra texture and freshness, you can add diced tomatoes, cucumbers, or even a sprinkle of chopped green onions for a bit of zing. Serve the salad cold, either as a quick, satisfying lunch or a refreshing snack. This salad also pairs well with whole-grain crackers or a slice of toasted bread on the side.", 25, null },
                    { new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281"), 200, 15, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, "https://www.kitchensanctuary.com/wp-content/uploads/2020/09/Cauliflower-Egg-Fried-Rice-square-FS-14.jpg", "Cauliflower, peas, carrots, soy sauce", "Cauliflower Fried Rice", "Begin by grating or processing the cauliflower until it resembles rice-sized pieces. In a large skillet, heat a bit of oil over medium heat, then add the peas and diced carrots. Sauté the vegetables for several minutes until they are tender. Add the cauliflower 'rice' and pour in a splash of soy sauce. Stir well to coat all of the cauliflower evenly with the sauce. Continue to cook, stirring frequently, for 5-7 minutes or until the cauliflower is tender but not mushy. Adjust seasoning if needed and serve hot as a side or main dish.", 5, null },
                    { new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1"), 400, 52, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 0, "https://www.simplyrecipes.com/thmb/gjS-FSuYnqK3fclkE2fWhYl1VWQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Simply-Recipes-Spaghetti-Aglio-e-Olio-LEAD-2-c8e7e8c6edb04a8691463c6ea8cd4ba1.jpg", "Spaghetti, garlic, olive oil, red pepper flakes", "Spaghetti Aglio e Olio", "Cook the spaghetti according to the package instructions, making sure it is al dente. While the spaghetti cooks, heat a generous amount of olive oil in a large skillet over medium heat. Add thinly sliced garlic and sauté gently, stirring frequently to avoid burning, until the garlic is golden brown and fragrant. Stir in the red pepper flakes to infuse the oil with a bit of heat. Drain the cooked spaghetti and add it directly to the skillet. Toss everything together until the spaghetti is evenly coated in the garlic-infused oil. Serve immediately, garnished with fresh parsley and grated Parmesan, if desired.", 12, null },
                    { new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"), 350, 20, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, "https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2021/05/Chicken-Stir-Fry-main-1.jpg", "Chicken breast, mixed vegetables, soy sauce, ginger", "Chicken Stir-Fry", "In a large skillet or wok, heat a bit of oil over medium-high heat. Add diced chicken breast and cook, stirring frequently, until the pieces are golden brown and cooked through. Next, add mixed vegetables (such as bell peppers, broccoli, and snap peas) along with a sprinkle of freshly grated ginger. Stir-fry the mixture for 5-7 minutes, stirring constantly, until the vegetables are tender-crisp. Add a splash of soy sauce and toss to coat everything evenly, cooking for another 2 minutes. Serve hot over rice or noodles for a complete meal.", 30, null },
                    { new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a"), 300, 20, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, "https://www.foodiecrush.com/wp-content/uploads/2016/08/Linguine-and-Zucchini-Noodles-with-Shrimp-foodiecrush.com-0014.jpg", "Zucchini, shrimp, garlic, olive oil, cherry tomatoes, parsley, salt, pepper", "Zucchini Noodles with Grilled Shrimp", "1. Use a spiralizer to turn 2 zucchinis into noodles. Set aside. 2. Season the shrimp with salt, pepper, and a minced garlic clove. 3. Heat 1 tablespoon of olive oil in a skillet over medium heat, then add the shrimp. Cook for 2-3 minutes per side until pink and opaque. Remove from the skillet and set aside. 4. In the same skillet, add more garlic and sauté until fragrant. 5. Add the zucchini noodles and cherry tomatoes, cooking for 2-3 minutes until slightly softened. 6. Return the shrimp to the skillet, toss with the noodles, and garnish with chopped parsley. Serve warm.", 25, null },
                    { new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e"), 150, 3, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, "https://images.eatthismuch.com/img/906792_tabitharwheeler_7ecdcbb2-52e2-456d-8c38-4194febe4830.jpg", "Egg whites, spinach, bell pepper, olive oil, salt, pepper", "Egg White Omelet with Spinach", "1. Whisk together 4 egg whites with a pinch of salt and pepper. 2. Heat 1 teaspoon of olive oil in a non-stick skillet over medium heat. 3. Add a handful of spinach and diced bell pepper to the skillet, cooking until the spinach wilts. 4. Pour the egg whites over the vegetables and cook for 2-3 minutes until the bottom sets. 5. Carefully fold the omelet in half and cook for another minute. 6. Slide the omelet onto a plate and serve immediately.", 20, null },
                    { new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"), 500, 30, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, "https://www.rachelcooks.com/wp-content/uploads/2022/09/Beef-Stir-Fry-with-Vegetables016-web-square.jpg", "Beef, bell peppers, onions, soy sauce", "Beef Stir-Fry", "Slice the beef thinly across the grain and season it with a pinch of salt and pepper. Heat a tablespoon of oil in a large skillet over medium-high heat. Add the beef and cook for 3-4 minutes until browned. Remove the beef and set aside. In the same skillet, add the sliced bell peppers and onions, cooking for about 5 minutes until tender. Add the beef back to the skillet along with soy sauce and a touch of honey or brown sugar for sweetness. Stir everything together and cook for another 2 minutes. Serve hot over rice or noodles.", 40, null },
                    { new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"), 300, 10, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, "https://tastythin.com/wp-content/uploads/2020/02/asian-turkey-lettuce-wraps2-500x500.jpg", "Ground turkey, lettuce, tomatoes, avocado", "Turkey Lettuce Wraps", "In a skillet over medium heat, cook the ground turkey until browned, breaking it up with a spoon as it cooks. Season with salt, pepper, and a dash of cumin if desired. Wash and dry large lettuce leaves, which will serve as the wraps. Once the turkey is cooked through, spoon it into each lettuce leaf and top with diced tomatoes and sliced avocado. Serve immediately for a low-carb, high-protein meal.", 28, null },
                    { new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294"), 250, 35, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, "https://www.nospoonnecessary.com/wp-content/uploads/2020/03/Beans-for-Tacos-recipe.jpg", "Black beans, corn tortillas, avocado, salsa", "Black Bean Tacos", "In a mixing bowl, mash the black beans lightly with a fork or potato masher, then season with a squeeze of fresh lime juice and a pinch of salt and pepper. Warm the corn tortillas in a dry skillet over medium heat for a few minutes on each side until soft and pliable. To assemble the tacos, spread a spoonful of the black bean mixture onto each tortilla, top with diced avocado, and add a generous spoonful of salsa. Serve immediately, garnished with lime wedges for squeezing over the tacos for added flavor.", 10, null },
                    { new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"), 300, 45, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, "https://images.getrecipekit.com/20230919180123-greek-20yogurt-20parfait.png?aspect_ratio=1:1&quality=90&", "Greek yogurt, berries, honey, granola", "Greek Yogurt Parfait", "In a glass or bowl, start by adding a layer of Greek yogurt at the bottom. Next, add a layer of fresh berries like strawberries, blueberries, or raspberries. Drizzle a teaspoon of honey over the berries to add a touch of sweetness. Add a layer of granola for crunch. Repeat the layers until the glass or bowl is filled, finishing with a few berries and a final drizzle of honey on top. Serve immediately for a refreshing and protein-packed breakfast or snack.", 15, null },
                    { new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"), 400, 50, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_4:3/k%2FPhoto%2FRecipes%2F2019-11-recipe-mediterranean-quinoa-salad%2F2019-10-21_Kitchn89095_Mediteranean-Quinoa-Salad", "Quinoa, cherry tomatoes, cucumber, feta cheese", "Quinoa Salad", "Cook the quinoa according to the package instructions, then let it cool to room temperature. In a large bowl, combine the cooked quinoa with halved cherry tomatoes, diced cucumber, and crumbled feta cheese. Drizzle with olive oil and a squeeze of fresh lemon juice, and season with salt and pepper to taste. Toss everything together gently to ensure the ingredients are evenly mixed. Serve chilled or at room temperature, optionally garnished with fresh herbs like parsley or mint for added freshness.", 12, null },
                    { new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021"), 600, 75, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, "https://storage.googleapis.com/ayuvya_images/blog_image/5_Best_Smoothie_Recipes_for_Weight_Gain_You_Need_to_Try_Now.webp", "Milk, banana, peanut butter, protein powder, oats, honey", "Mass-Gain Smoothie", "1. Pour 1 cup of milk into a blender. Add a peeled banana, 2 tablespoons of peanut butter, 1 scoop of protein powder, 1/4 cup of oats, and 1 tablespoon of honey. 2. Blend all ingredients on high until the mixture is smooth and creamy, ensuring no chunks remain. 3. Taste and adjust sweetness with more honey if needed. 4. Pour into a large glass and serve chilled. Enjoy immediately for the best texture and flavor.", 30, null },
                    { new Guid("c670818c-d46f-440b-9332-0f0d01937887"), 400, 35, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 1, "https://mojo.generalmills.com/api/public/content/wD6Zdi1fS0OIerKfD62IBA_webp_base.webp?v=baa249d0&t=191ddcab8d1c415fa10fa00a14351227", "Bell peppers, ground beef, rice, cheese", "Stuffed Peppers", "Preheat the oven to 375°F (190°C). Slice the tops off the bell peppers and remove the seeds. In a skillet, brown the ground beef over medium heat. Mix in cooked rice and season with salt, pepper, and Italian herbs. Stuff the mixture into each bell pepper and place them in a baking dish. Top with shredded cheese and bake for about 25-30 minutes until the peppers are tender and the cheese is bubbly.", 25, null },
                    { new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"), 250, 30, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/1D1F8AE8-0888-45CB-B21B-15377ADC6C9A/Derivates/874a16dd-d1b1-4db0-bc13-fab251938451.jpg", "Protein powder, almond milk, banana, spinach", "Protein Smoothie", "In a blender, add one scoop of protein powder, a cup of almond milk, a ripe banana, and a handful of fresh spinach leaves. Blend on high until the mixture is completely smooth and no chunks remain. Taste the smoothie and add a bit of honey if you want extra sweetness. For a colder smoothie, you can add a few ice cubes or use a frozen banana. Pour into a glass and enjoy immediately for a nutritious breakfast or post-workout snack.", 20, null },
                    { new Guid("d2155f29-4a5a-4e71-a1ef-cb493b45bc4d"), 500, 70, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, "https://thestayathomechef.com/wp-content/uploads/2021/01/Mediterranean-Chickpea-Salad-1-1200x720.jpg", "Chickpeas, brown rice, cucumber, tahini", "Mediterranean Chickpea Bowl", "Begin by cooking the brown rice according to the package instructions, then let it cool slightly. In a large bowl, combine the cooked rice with chickpeas (drained and rinsed if canned) and diced cucumber. Drizzle with a generous amount of tahini, and season with salt and pepper to taste. Squeeze fresh lemon juice over the bowl and garnish with freshly chopped parsley for added flavor. Serve immediately or refrigerate for a chilled version of this Mediterranean-inspired dish.", 20, null },
                    { new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"), 450, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 0, "https://img.chefkoch-cdn.de/rezepte/1578671265353584/bilder/1509269/crop-960x540/chili-con-carne.jpg", "Ground beef, kidney beans, tomatoes, chili powder", "Chili Con Carne", "In a large pot, heat a bit of oil over medium heat and add the ground beef. Cook, stirring frequently to break up any large pieces, until the beef is browned and no longer pink. Once browned, add diced tomatoes, kidney beans (drained and rinsed if canned), and chili powder. Stir everything together and bring to a simmer. Lower the heat and let it cook for about 30 minutes, stirring occasionally to prevent sticking. Adjust seasonings to taste, adding salt, pepper, or more chili powder for heat. Serve hot, garnished with chopped cilantro, shredded cheese, or a dollop of sour cream for extra flavor.", 30, null },
                    { new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"), 450, 65, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, "https://cdn.loveandlemons.com/wp-content/uploads/2023/05/quinoa-bowl-recipe.jpg", "Quinoa, black beans, corn, avocado, lime", "Quinoa Bowl", "Cook quinoa according to package instructions. In a large bowl, combine cooked quinoa, rinsed black beans, corn, and diced avocado. Squeeze fresh lime juice over the top and toss gently to combine. Season with salt and pepper to taste. For added flavor, you can also add chopped cilantro or diced jalapeño. Serve chilled or at room temperature as a nutritious and filling meal.", 15, null },
                    { new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921"), 650, 50, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 1, "https://dianasdelishdishes.com/wp-content/uploads/2023/06/C42B7659-56C9-42D0-BF0E-0A34B78BE0A5.jpeg", "Ground beef, sweet potato, olive oil, spinach, garlic, salt, pepper", "Beef and Sweet Potato Power Bowl", "1. Preheat the oven to 400°F (200°C). 2. Peel and cube the sweet potato, then toss with 1 tablespoon of olive oil, salt, and pepper. 3. Spread the cubes on a baking sheet and roast for 20-25 minutes, turning halfway, until tender and golden. 4. While the sweet potato cooks, heat a skillet over medium heat and add 1 tablespoon of olive oil. 5. Add 1 minced garlic clove, cooking until fragrant. Add the ground beef, seasoning with salt and pepper, and cook until browned, breaking it apart as it cooks. 6. Remove the beef from the heat and set aside. 7. In the same pan, lightly sauté a handful of spinach until wilted. 8. In a bowl, layer the roasted sweet potatoes, beef, and spinach, adding more seasoning if desired. Serve warm.", 40, null },
                    { new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"), 250, 30, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, "https://cdn.loveandlemons.com/wp-content/uploads/2023/05/chickpea-salad-500x500.jpg", "Chickpeas, cucumber, tomatoes, lemon, olive oil", "Chickpea Salad", "In a large mixing bowl, combine drained chickpeas, diced cucumber, and chopped tomatoes, making sure the ingredients are evenly distributed. Drizzle the mixture with freshly squeezed lemon juice and a generous splash of olive oil, adjusting both to your taste. Season with salt and pepper, then toss everything thoroughly until well mixed. For the best flavor, allow the salad to marinate in the fridge for at least 30 minutes, letting the chickpeas absorb the lemon and olive oil. This salad can be served immediately, but chilling enhances the flavors, making it a refreshing side dish or light meal.", 12, null },
                    { new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"), 350, 12, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://www.thespruceeats.com/thmb/1HuTabE4tSdTe8YDcdiR2ts2P3Y=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/california-grilled-chicken-salad-recipe-334159-13-8ecd934fee5e42f8b5d38239b083460b.jpg", "Chicken breast, lettuce, cucumber, tomatoes, olive oil", "Grilled Chicken Salad", "Season the chicken breast with salt, pepper, and a bit of garlic powder. Heat a grill pan over medium heat and cook the chicken breast for 6-7 minutes on each side, until fully cooked. Let the chicken cool slightly, then slice it thinly. In a large bowl, combine chopped lettuce, cucumber, and tomatoes. Drizzle with olive oil and toss to coat. Top with sliced chicken and serve with a light vinaigrette or dressing of your choice.", 35, null },
                    { new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"), 480, 40, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://tastesbetterfromscratch.com/wp-content/uploads/2014/03/Chicken-Bacon-Avocado-Wrap-1.jpg", "Grilled chicken breast, whole wheat wrap, avocado, tomato, lettuce, Greek yogurt", "Chicken Avocado Wrap", "1. Slice the grilled chicken breast into thin strips. 2. Warm the whole wheat wrap in a dry skillet over medium heat for 1-2 minutes on each side. 3. While the wrap warms, peel and mash 1/2 avocado in a bowl until smooth. 4. Spread a thin layer of Greek yogurt onto the center of the warm wrap. 5. Add the sliced chicken, mashed avocado, tomato slices, and a handful of lettuce. 6. Season with salt and pepper to taste. 7. Fold the bottom of the wrap up, then roll tightly from one side to the other. 8. Cut in half and enjoy immediately.", 30, null },
                    { new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"), 200, 25, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, "https://simple-veganista.com/wp-content/uploads/2017/04/chocolate-chia-pudding-1.jpg", "Chia seeds, almond milk, cocoa powder, honey", "Chocolate Chia Pudding", "In a bowl, mix chia seeds and cocoa powder with almond milk, stirring thoroughly to ensure there are no clumps. Sweeten with honey to taste, adjusting as desired. Cover the bowl and refrigerate for at least 4 hours, preferably overnight, to allow the chia seeds to absorb the liquid and form a pudding-like consistency. Before serving, stir once more to ensure even texture, then top with fresh fruit, nuts, or shredded coconut for added flavor and crunch. Serve chilled for a refreshing, nutritious dessert.", 5, null },
                    { new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"), 200, 32, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, "https://www.kitchensanctuary.com/wp-content/uploads/2021/10/Sweet-Potato-Fries-wideFS-20.webp", "Sweet potatoes, olive oil, salt, pepper", "Sweet Potato Fries", "Preheat the oven to 425°F (220°C). Cut the sweet potatoes into thin strips, aiming for even sizes to ensure uniform cooking. Place the cut sweet potatoes in a large bowl, drizzle with olive oil, and season generously with salt and pepper. Toss well, making sure each piece is coated. Spread the sweet potato strips on a baking sheet lined with parchment paper in a single layer to allow proper air circulation for crispiness. Bake for 20-25 minutes, flipping halfway through to ensure even browning. For extra crunch, you can bake a few minutes longer. Serve hot, perfect as a side dish or snack.", 3, null }
                });

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

            migrationBuilder.InsertData(
                table: "DietsRecipes",
                columns: new[] { "DietId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") },
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("c1d5a8e3-9a7a-4d77-bb38-8aafd82df021") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("816b8eec-5ff7-408e-a903-55f509b97302") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("816b8eec-5ff7-408e-a903-55f509b97302") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a") },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921") },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1") },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("ce451c31-e002-4e97-9140-dc81837b58a7") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921") },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("2995c236-5b5d-42f9-89b5-15576256ee66") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222") },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b") }
                });

            migrationBuilder.InsertData(
                table: "WorkoutsExercises",
                columns: new[] { "ExerciseId", "WorkoutId" },
                values: new object[,]
                {
                    { new Guid("2a8ed1d9-84d3-4fd4-83e2-2c4391f0b01b"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                    { new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                    { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                    { new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"), new Guid("a7474e22-a2f1-4f2e-88be-fadc97cc4fd8") },
                    { new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                    { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                    { new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                    { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("ab8e1eaa-96b1-4a4e-aa92-3a30d5297f49") },
                    { new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                    { new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                    { new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                    { new Guid("d4f5b8b7-5638-4882-9254-07f5f35c09d6"), new Guid("c4a9f0d5-44bf-4a0d-833e-a7673d8a7539") },
                    { new Guid("3e9a5c5f-8d7e-4b2c-923b-27c4a6e2a6d7"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                    { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                    { new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                    { new Guid("ff5e9f1a-8f9f-4a8f-9081-d17b9e6fbe3c"), new Guid("cb33f115-f082-418a-afb4-02762aa8c235") },
                    { new Guid("3e6c1f4b-0e5d-4f8d-8b2b-1a0e37dce9b7"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                    { new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                    { new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                    { new Guid("c9b4f5f1-1e3d-4a93-9d42-bb27a1b4b315"), new Guid("f2095d49-635e-4617-a470-491008eb7621") },
                    { new Guid("dbb7b1c4-72e8-4a37-91a7-fb97d4b4f0e3"), new Guid("f2095d49-635e-4617-a470-491008eb7621") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserID",
                table: "Diets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DietsRecipes_RecipeId",
                table: "DietsRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_UserID",
                table: "Progresses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserID",
                table: "Recipes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_DietId",
                table: "UsersDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersWorkouts_UserId",
                table: "UsersWorkouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserID",
                table: "Workouts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutsExercises_ExerciseId",
                table: "WorkoutsExercises",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DietsRecipes");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "UsersDiets");

            migrationBuilder.DropTable(
                name: "UsersWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutsExercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
