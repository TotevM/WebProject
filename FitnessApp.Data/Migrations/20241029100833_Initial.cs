using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MuscleGroup = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietsFoods",
                columns: table => new
                {
                    DietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsFoods", x => new { x.DietId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_DietsFoods_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietsFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutsExercises",
                columns: table => new
                {
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                table: "Recipes",
                columns: new[] { "Id", "Goal", "ImageUrl", "Ingredients", "Name", "Preparation", "UserID" },
                values: new object[,]
                {
                    { new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"), 0, "https://www.whollytasteful.com/wp-content/uploads/2022/09/protein-pancakes-with-oats-featured.jpg", "Oats, banana, protein powder, eggs", "Protein Pancakes", "In a blender, combine the oats, banana, protein powder, and eggs. Blend until the mixture is smooth and free of lumps. Heat a non-stick pan over medium heat and lightly coat it with cooking spray. Pour a small amount of the batter onto the pan and cook for 2-3 minutes until bubbles appear on the surface. Flip the pancake and cook for an additional 2 minutes on the other side. Serve warm, topped with fresh berries or a drizzle of honey for added flavor.", null },
                    { new Guid("2f2c8c6d-2e2f-4b5f-98a5-c3d2e6f1d8c4"), 2, "https://cdn.loveandlemons.com/wp-content/uploads/opengraph/2014/10/vegetable-soup.jpg", "Carrots, celery, onion, tomato, spinach", "Vegetable Soup", "In a large pot, heat a tablespoon of olive oil over medium heat. Add chopped carrots, celery, and onion, and sauté for 5-7 minutes until the vegetables begin to soften. Add chopped tomatoes and a few cups of water or vegetable broth. Bring to a boil, then reduce the heat and simmer for 15-20 minutes. Stir in spinach and cook for an additional 5 minutes. Season with salt and pepper, and serve hot.", null },
                    { new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"), 1, "https://tealnotes.com/wp-content/uploads/2023/05/Featured-Image-46-800x530.png", "Eggs, salt, bell pepper, spinach", "Scrambled Eggs with Veggies", "Crack the eggs into a bowl, add a pinch of salt, and whisk until smooth. Heat a small amount of olive oil in a non-stick skillet over medium heat. Add diced bell pepper and cook for 2-3 minutes until softened. Add the spinach and cook until wilted, about 1 minute. Pour the eggs into the pan and gently stir with a spatula, folding the eggs over themselves until just set. Remove from heat while the eggs are still slightly soft. Serve hot, garnished with fresh herbs if desired.", null },
                    { new Guid("4e3c9b5c-3c4e-4b3e-914a-7d9b5e6d4f2b"), 2, "https://joybauer.com/wp-content/uploads/2017/12/Oatmeal-with-berries2.jpg", "Oats, almond milk, blueberries, honey", "Oatmeal with Berries", "In a small pot, combine oats and almond milk and bring to a simmer over medium heat. Stir occasionally for 5-7 minutes until the oats are tender and the mixture is creamy. Pour the oatmeal into a bowl and top with fresh blueberries. Drizzle with honey for added sweetness. For added flavor, sprinkle a pinch of cinnamon or a handful of nuts on top.", null },
                    { new Guid("5e4b760e-6b49-4c6d-99a2-8a56e65f8dfd"), 1, "https://cdn.loveandlemons.com/wp-content/uploads/2023/01/cauliflower-fried-rice.jpg", "Cauliflower rice, bell pepper, soy sauce, carrots", "Cauliflower Rice Stir Fry", "In a large skillet or wok, heat a tablespoon of oil over medium-high heat. Add diced bell peppers and sliced carrots, cooking for 5-7 minutes until tender. Add cauliflower rice and a splash of soy sauce, stirring to combine. Cook for an additional 3-4 minutes, until the cauliflower is tender but not mushy. Season with salt and pepper to taste, and serve hot as a healthy alternative to traditional fried rice.", null },
                    { new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1"), 0, "https://img.buzzfeed.com/thumbnailer-prod-us-east-1/video-api/assets/13385.jpg", "Chicken breast, brown rice, broccoli", "Chicken and Rice", "Start by seasoning the chicken breast with salt, pepper, and your favorite spices. Heat a grill pan over medium heat and cook the chicken for about 5-6 minutes on each side, or until fully cooked. Meanwhile, bring a pot of water to a boil and add the brown rice, cooking for about 30-35 minutes until tender. Steam the broccoli for 5-7 minutes, until it is bright green and slightly tender. Serve the grilled chicken over the rice with a side of steamed broccoli. Optionally, drizzle with a little olive oil or lemon juice.", null },
                    { new Guid("91c5c3e1-81c3-4b5f-9f5f-9d3c7e6f4c3b"), 2, "https://www.allrecipes.com/thmb/8NccFzsaq0_OZPDKmf7Yee-aG78=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/AvocadoToastwithEggFranceC4x3-bb87e3bbf1944657b7db35f1383fabdb.jpg", "Whole grain bread, avocado, salt, pepper, egg", "Avocado Toast", "Toast a slice of whole-grain bread to your desired level of crispness. While the bread is toasting, cut a ripe avocado in half, remove the pit, and scoop the flesh into a bowl. Mash the avocado with a fork until smooth, then season with a pinch of salt and pepper. Spread the avocado on the toasted bread, and top with additional toppings if desired, such as cherry tomatoes, a sprinkle of chili flakes, or a drizzle of olive oil.", null },
                    { new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"), 0, "https://www.rachelcooks.com/wp-content/uploads/2022/09/Beef-Stir-Fry-with-Vegetables016-web-square.jpg", "Beef, bell peppers, onions, soy sauce", "Beef Stir-Fry", "Slice the beef thinly across the grain and season it with a pinch of salt and pepper. Heat a tablespoon of oil in a large skillet over medium-high heat. Add the beef and cook for 3-4 minutes until browned. Remove the beef and set aside. In the same skillet, add the sliced bell peppers and onions, cooking for about 5 minutes until tender. Add the beef back to the skillet along with soy sauce and a touch of honey or brown sugar for sweetness. Stir everything together and cook for another 2 minutes. Serve hot over rice or noodles.", null },
                    { new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"), 1, "https://tastythin.com/wp-content/uploads/2020/02/asian-turkey-lettuce-wraps2-500x500.jpg", "Ground turkey, lettuce, tomatoes, avocado", "Turkey Lettuce Wraps", "In a skillet over medium heat, cook the ground turkey until browned, breaking it up with a spoon as it cooks. Season with salt, pepper, and a dash of cumin if desired. Wash and dry large lettuce leaves, which will serve as the wraps. Once the turkey is cooked through, spoon it into each lettuce leaf and top with diced tomatoes and sliced avocado. Serve immediately for a low-carb, high-protein meal.", null },
                    { new Guid("ab7fbc1c-5d7d-4d79-9dfd-9b8e7059254b"), 1, "https://cdn.copymethat.com/media/orig_zucchini_noodles_with_marinara_sauce_20240311183101524418a8shb.jpg", "Zucchini, marinara sauce, garlic, basil", "Zucchini Noodles with Marinara", "Using a spiralizer, turn the zucchini into noodles. Heat a pan over medium heat, add a touch of olive oil, and sauté minced garlic until fragrant. Add the zucchini noodles and cook for 2-3 minutes until slightly softened. Add marinara sauce to the pan and stir until the noodles are evenly coated. Cook for another 1-2 minutes, garnish with fresh basil, and serve immediately.", null },
                    { new Guid("b0c29b2d-c5c5-489a-9140-98c8d6e8a53e"), 2, "https://www.purelykaylie.com/wp-content/uploads/2021/02/Simple-Green-Smoothie-6.jpg", "Spinach, banana, almond milk, chia seeds", "Green Smoothie", "In a blender, combine a handful of spinach, one banana, a cup of almond milk, and a tablespoon of chia seeds. Blend on high speed until the mixture is smooth and creamy, with no visible chunks. For a thicker texture, you can add ice cubes or a second banana. Pour the smoothie into a glass and drink immediately for maximum freshness and nutrient retention.", null },
                    { new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"), 0, "https://images.getrecipekit.com/20230919180123-greek-20yogurt-20parfait.png?aspect_ratio=1:1&quality=90&", "Greek yogurt, berries, honey, granola", "Greek Yogurt Parfait", "In a glass or bowl, start by adding a layer of Greek yogurt at the bottom. Next, add a layer of fresh berries like strawberries, blueberries, or raspberries. Drizzle a teaspoon of honey over the berries to add a touch of sweetness. Add a layer of granola for crunch. Repeat the layers until the glass or bowl is filled, finishing with a few berries and a final drizzle of honey on top. Serve immediately for a refreshing and protein-packed breakfast or snack.", null },
                    { new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"), 0, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/1D1F8AE8-0888-45CB-B21B-15377ADC6C9A/Derivates/874a16dd-d1b1-4db0-bc13-fab251938451.jpg", "Protein powder, almond milk, banana, spinach", "Protein Smoothie", "In a blender, add one scoop of protein powder, a cup of almond milk, a ripe banana, and a handful of fresh spinach leaves. Blend on high until the mixture is completely smooth and no chunks remain. Taste the smoothie and add a bit of honey if you want extra sweetness. For a colder smoothie, you can add a few ice cubes or use a frozen banana. Pour into a glass and enjoy immediately for a nutritious breakfast or post-workout snack.", null },
                    { new Guid("d2b5c8f8-3a2d-4b6e-9a8a-5c8c8f7c1e4d"), 2, "https://www.eatingbirdfood.com/wp-content/uploads/2023/04/protein-chia-pudding-new-hero-cropped.jpg", "Chia seeds, almond milk, honey, berries", "Chia Pudding", "In a bowl or jar, combine chia seeds with almond milk and stir well to prevent clumping. Sweeten with a teaspoon of honey if desired. Cover and refrigerate for at least 4 hours, or overnight, until the chia seeds have absorbed the liquid and the mixture has thickened to a pudding-like consistency. Serve topped with fresh berries for a tasty and nutritious breakfast or snack.", null },
                    { new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"), 1, "https://gimmesomegrilling.com/wp-content/uploads/2021/05/Grilled-Chicken-Salad-Recipe-Square.jpg", "Chicken breast, lettuce, cucumber, tomatoes, olive oil", "Grilled Chicken Salad", "Season the chicken breast with salt, pepper, and a bit of garlic powder. Heat a grill pan over medium heat and cook the chicken breast for 6-7 minutes on each side, until fully cooked. Let the chicken cool slightly, then slice it thinly. In a large bowl, combine chopped lettuce, cucumber, and tomatoes. Drizzle with olive oil and toss to coat. Top with sliced chicken and serve with a light vinaigrette or dressing of your choice.", null }
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
                name: "IX_DietsFoods_FoodId",
                table: "DietsFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_UserID",
                table: "Progresses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserID",
                table: "Recipes",
                column: "UserID");

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
                name: "DietsFoods");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "WorkoutsExercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
