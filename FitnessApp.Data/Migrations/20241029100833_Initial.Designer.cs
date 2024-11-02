﻿// <auto-generated />
using System;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    [DbContext(typeof(FitnessDBContext))]
    [Migration("20241029100833_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Diet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.DietFood", b =>
                {
                    b.Property<Guid>("DietId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("DietId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("DietsFoods");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Carbs")
                        .HasColumnType("int");

                    b.Property<int>("Fats")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Weight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Progresses");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Preparation")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"),
                            Goal = 0,
                            ImageUrl = "https://www.whollytasteful.com/wp-content/uploads/2022/09/protein-pancakes-with-oats-featured.jpg",
                            Ingredients = "Oats, banana, protein powder, eggs",
                            Name = "Protein Pancakes",
                            Preparation = "In a blender, combine the oats, banana, protein powder, and eggs. Blend until the mixture is smooth and free of lumps. Heat a non-stick pan over medium heat and lightly coat it with cooking spray. Pour a small amount of the batter onto the pan and cook for 2-3 minutes until bubbles appear on the surface. Flip the pancake and cook for an additional 2 minutes on the other side. Serve warm, topped with fresh berries or a drizzle of honey for added flavor."
                        },
                        new
                        {
                            Id = new Guid("7fcf8f67-0b44-4be5-9f55-3fd8f0bcb4d1"),
                            Goal = 0,
                            ImageUrl = "https://img.buzzfeed.com/thumbnailer-prod-us-east-1/video-api/assets/13385.jpg",
                            Ingredients = "Chicken breast, brown rice, broccoli",
                            Name = "Chicken and Rice",
                            Preparation = "Start by seasoning the chicken breast with salt, pepper, and your favorite spices. Heat a grill pan over medium heat and cook the chicken for about 5-6 minutes on each side, or until fully cooked. Meanwhile, bring a pot of water to a boil and add the brown rice, cooking for about 30-35 minutes until tender. Steam the broccoli for 5-7 minutes, until it is bright green and slightly tender. Serve the grilled chicken over the rice with a side of steamed broccoli. Optionally, drizzle with a little olive oil or lemon juice."
                        },
                        new
                        {
                            Id = new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"),
                            Goal = 0,
                            ImageUrl = "https://www.rachelcooks.com/wp-content/uploads/2022/09/Beef-Stir-Fry-with-Vegetables016-web-square.jpg",
                            Ingredients = "Beef, bell peppers, onions, soy sauce",
                            Name = "Beef Stir-Fry",
                            Preparation = "Slice the beef thinly across the grain and season it with a pinch of salt and pepper. Heat a tablespoon of oil in a large skillet over medium-high heat. Add the beef and cook for 3-4 minutes until browned. Remove the beef and set aside. In the same skillet, add the sliced bell peppers and onions, cooking for about 5 minutes until tender. Add the beef back to the skillet along with soy sauce and a touch of honey or brown sugar for sweetness. Stir everything together and cook for another 2 minutes. Serve hot over rice or noodles."
                        },
                        new
                        {
                            Id = new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"),
                            Goal = 0,
                            ImageUrl = "https://images.getrecipekit.com/20230919180123-greek-20yogurt-20parfait.png?aspect_ratio=1:1&quality=90&",
                            Ingredients = "Greek yogurt, berries, honey, granola",
                            Name = "Greek Yogurt Parfait",
                            Preparation = "In a glass or bowl, start by adding a layer of Greek yogurt at the bottom. Next, add a layer of fresh berries like strawberries, blueberries, or raspberries. Drizzle a teaspoon of honey over the berries to add a touch of sweetness. Add a layer of granola for crunch. Repeat the layers until the glass or bowl is filled, finishing with a few berries and a final drizzle of honey on top. Serve immediately for a refreshing and protein-packed breakfast or snack."
                        },
                        new
                        {
                            Id = new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"),
                            Goal = 0,
                            ImageUrl = "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/1D1F8AE8-0888-45CB-B21B-15377ADC6C9A/Derivates/874a16dd-d1b1-4db0-bc13-fab251938451.jpg",
                            Ingredients = "Protein powder, almond milk, banana, spinach",
                            Name = "Protein Smoothie",
                            Preparation = "In a blender, add one scoop of protein powder, a cup of almond milk, a ripe banana, and a handful of fresh spinach leaves. Blend on high until the mixture is completely smooth and no chunks remain. Taste the smoothie and add a bit of honey if you want extra sweetness. For a colder smoothie, you can add a few ice cubes or use a frozen banana. Pour into a glass and enjoy immediately for a nutritious breakfast or post-workout snack."
                        },
                        new
                        {
                            Id = new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"),
                            Goal = 1,
                            ImageUrl = "https://tealnotes.com/wp-content/uploads/2023/05/Featured-Image-46-800x530.png",
                            Ingredients = "Eggs, salt, bell pepper, spinach",
                            Name = "Scrambled Eggs with Veggies",
                            Preparation = "Crack the eggs into a bowl, add a pinch of salt, and whisk until smooth. Heat a small amount of olive oil in a non-stick skillet over medium heat. Add diced bell pepper and cook for 2-3 minutes until softened. Add the spinach and cook until wilted, about 1 minute. Pour the eggs into the pan and gently stir with a spatula, folding the eggs over themselves until just set. Remove from heat while the eggs are still slightly soft. Serve hot, garnished with fresh herbs if desired."
                        },
                        new
                        {
                            Id = new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"),
                            Goal = 1,
                            ImageUrl = "https://tastythin.com/wp-content/uploads/2020/02/asian-turkey-lettuce-wraps2-500x500.jpg",
                            Ingredients = "Ground turkey, lettuce, tomatoes, avocado",
                            Name = "Turkey Lettuce Wraps",
                            Preparation = "In a skillet over medium heat, cook the ground turkey until browned, breaking it up with a spoon as it cooks. Season with salt, pepper, and a dash of cumin if desired. Wash and dry large lettuce leaves, which will serve as the wraps. Once the turkey is cooked through, spoon it into each lettuce leaf and top with diced tomatoes and sliced avocado. Serve immediately for a low-carb, high-protein meal."
                        },
                        new
                        {
                            Id = new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"),
                            Goal = 1,
                            ImageUrl = "https://gimmesomegrilling.com/wp-content/uploads/2021/05/Grilled-Chicken-Salad-Recipe-Square.jpg",
                            Ingredients = "Chicken breast, lettuce, cucumber, tomatoes, olive oil",
                            Name = "Grilled Chicken Salad",
                            Preparation = "Season the chicken breast with salt, pepper, and a bit of garlic powder. Heat a grill pan over medium heat and cook the chicken breast for 6-7 minutes on each side, until fully cooked. Let the chicken cool slightly, then slice it thinly. In a large bowl, combine chopped lettuce, cucumber, and tomatoes. Drizzle with olive oil and toss to coat. Top with sliced chicken and serve with a light vinaigrette or dressing of your choice."
                        },
                        new
                        {
                            Id = new Guid("5e4b760e-6b49-4c6d-99a2-8a56e65f8dfd"),
                            Goal = 1,
                            ImageUrl = "https://cdn.loveandlemons.com/wp-content/uploads/2023/01/cauliflower-fried-rice.jpg",
                            Ingredients = "Cauliflower rice, bell pepper, soy sauce, carrots",
                            Name = "Cauliflower Rice Stir Fry",
                            Preparation = "In a large skillet or wok, heat a tablespoon of oil over medium-high heat. Add diced bell peppers and sliced carrots, cooking for 5-7 minutes until tender. Add cauliflower rice and a splash of soy sauce, stirring to combine. Cook for an additional 3-4 minutes, until the cauliflower is tender but not mushy. Season with salt and pepper to taste, and serve hot as a healthy alternative to traditional fried rice."
                        },
                        new
                        {
                            Id = new Guid("ab7fbc1c-5d7d-4d79-9dfd-9b8e7059254b"),
                            Goal = 1,
                            ImageUrl = "https://cdn.copymethat.com/media/orig_zucchini_noodles_with_marinara_sauce_20240311183101524418a8shb.jpg",
                            Ingredients = "Zucchini, marinara sauce, garlic, basil",
                            Name = "Zucchini Noodles with Marinara",
                            Preparation = "Using a spiralizer, turn the zucchini into noodles. Heat a pan over medium heat, add a touch of olive oil, and sauté minced garlic until fragrant. Add the zucchini noodles and cook for 2-3 minutes until slightly softened. Add marinara sauce to the pan and stir until the noodles are evenly coated. Cook for another 1-2 minutes, garnish with fresh basil, and serve immediately."
                        },
                        new
                        {
                            Id = new Guid("91c5c3e1-81c3-4b5f-9f5f-9d3c7e6f4c3b"),
                            Goal = 2,
                            ImageUrl = "https://www.allrecipes.com/thmb/8NccFzsaq0_OZPDKmf7Yee-aG78=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/AvocadoToastwithEggFranceC4x3-bb87e3bbf1944657b7db35f1383fabdb.jpg",
                            Ingredients = "Whole grain bread, avocado, salt, pepper, egg",
                            Name = "Avocado Toast",
                            Preparation = "Toast a slice of whole-grain bread to your desired level of crispness. While the bread is toasting, cut a ripe avocado in half, remove the pit, and scoop the flesh into a bowl. Mash the avocado with a fork until smooth, then season with a pinch of salt and pepper. Spread the avocado on the toasted bread, and top with additional toppings if desired, such as cherry tomatoes, a sprinkle of chili flakes, or a drizzle of olive oil."
                        },
                        new
                        {
                            Id = new Guid("b0c29b2d-c5c5-489a-9140-98c8d6e8a53e"),
                            Goal = 2,
                            ImageUrl = "https://www.purelykaylie.com/wp-content/uploads/2021/02/Simple-Green-Smoothie-6.jpg",
                            Ingredients = "Spinach, banana, almond milk, chia seeds",
                            Name = "Green Smoothie",
                            Preparation = "In a blender, combine a handful of spinach, one banana, a cup of almond milk, and a tablespoon of chia seeds. Blend on high speed until the mixture is smooth and creamy, with no visible chunks. For a thicker texture, you can add ice cubes or a second banana. Pour the smoothie into a glass and drink immediately for maximum freshness and nutrient retention."
                        },
                        new
                        {
                            Id = new Guid("d2b5c8f8-3a2d-4b6e-9a8a-5c8c8f7c1e4d"),
                            Goal = 2,
                            ImageUrl = "https://www.eatingbirdfood.com/wp-content/uploads/2023/04/protein-chia-pudding-new-hero-cropped.jpg",
                            Ingredients = "Chia seeds, almond milk, honey, berries",
                            Name = "Chia Pudding",
                            Preparation = "In a bowl or jar, combine chia seeds with almond milk and stir well to prevent clumping. Sweeten with a teaspoon of honey if desired. Cover and refrigerate for at least 4 hours, or overnight, until the chia seeds have absorbed the liquid and the mixture has thickened to a pudding-like consistency. Serve topped with fresh berries for a tasty and nutritious breakfast or snack."
                        },
                        new
                        {
                            Id = new Guid("2f2c8c6d-2e2f-4b5f-98a5-c3d2e6f1d8c4"),
                            Goal = 2,
                            ImageUrl = "https://cdn.loveandlemons.com/wp-content/uploads/opengraph/2014/10/vegetable-soup.jpg",
                            Ingredients = "Carrots, celery, onion, tomato, spinach",
                            Name = "Vegetable Soup",
                            Preparation = "In a large pot, heat a tablespoon of olive oil over medium heat. Add chopped carrots, celery, and onion, and sauté for 5-7 minutes until the vegetables begin to soften. Add chopped tomatoes and a few cups of water or vegetable broth. Bring to a boil, then reduce the heat and simmer for 15-20 minutes. Stir in spinach and cook for an additional 5 minutes. Season with salt and pepper, and serve hot."
                        },
                        new
                        {
                            Id = new Guid("4e3c9b5c-3c4e-4b3e-914a-7d9b5e6d4f2b"),
                            Goal = 2,
                            ImageUrl = "https://joybauer.com/wp-content/uploads/2017/12/Oatmeal-with-berries2.jpg",
                            Ingredients = "Oats, almond milk, blueberries, honey",
                            Name = "Oatmeal with Berries",
                            Preparation = "In a small pot, combine oats and almond milk and bring to a simmer over medium heat. Stir occasionally for 5-7 minutes until the oats are tender and the mixture is creamy. Pour the oatmeal into a bowl and top with fresh blueberries. Drizzle with honey for added sweetness. For added flavor, sprinkle a pinch of cinnamon or a handful of nuts on top."
                        });
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MuscleGroup")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.WorkoutExercise", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WorkoutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("WorkoutsExercises");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Diet", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.DietFood", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.Diet", "Diet")
                        .WithMany("DietsFoods")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Data.Models.Food", "Food")
                        .WithMany("DietsFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Progress", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Recipe", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Workout", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.WorkoutExercise", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.Exercise", "Exercise")
                        .WithMany("WorkoutsExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Data.Models.Workout", "Workout")
                        .WithMany("WorkoutsExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Diet", b =>
                {
                    b.Navigation("DietsFoods");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Exercise", b =>
                {
                    b.Navigation("WorkoutsExercises");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Food", b =>
                {
                    b.Navigation("DietsFoods");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Workout", b =>
                {
                    b.Navigation("WorkoutsExercises");
                });
#pragma warning restore 612, 618
        }
    }
}