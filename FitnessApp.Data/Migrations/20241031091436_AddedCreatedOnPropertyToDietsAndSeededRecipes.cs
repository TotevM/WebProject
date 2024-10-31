using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedOnPropertyToDietsAndSeededRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Diets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedOn", "Fats", "Goal", "ImageUrl", "Ingredients", "IsDeleted", "Name", "Preparation", "Protein", "UserID" },
                values: new object[,]
                {
                    { new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"), 350, 30, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, "https://www.allrecipes.com/thmb/8NccFzsaq0_OZPDKmf7Yee-aG78=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/AvocadoToastwithEggFranceC4x3-bb87e3bbf1944657b7db35f1383fabdb.jpg", "Bread, avocado, salt, pepper, lemon", false, "Avocado Toast", "Toast the bread to your desired crispiness. Mash the avocado in a bowl and season with salt, pepper, and a squeeze of lemon juice. Spread the mashed avocado over the toasted bread. Optional toppings include sliced tomatoes, radishes, or a poached egg.", 10, null },
                    { new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"), 350, 30, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, "https://thebeanbites.com/wp-content/uploads/2020/03/Instant-Pot-Stuffed-Peppers-10-720x540.jpg", "Bell peppers, ground turkey, quinoa, cheese", false, "Stuffed Bell Peppers", "Preheat oven to 375°F (190°C). Cut the tops off bell peppers and remove seeds. In a bowl, mix cooked quinoa, ground turkey, and cheese. Stuff the mixture into the peppers. Place in a baking dish, cover with foil, and bake for 30 minutes. Uncover and bake for an additional 10 minutes.", 25, null },
                    { new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"), 300, 40, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, "https://assets.bonappetit.com/photos/5a05c9df3388d32a6ed54e97/1:1/w_2560%2Cc_limit/curried-lentil-tomato-and-coconut-soup.jpg", "Lentils, coconut milk, curry powder, vegetables", false, "Coconut Curry Lentil Soup", "In a pot, sauté chopped vegetables until soft. Add lentils, coconut milk, curry powder, and water. Bring to a boil, then reduce heat and simmer until lentils are tender, about 20-25 minutes. Season with salt and pepper to taste.", 15, null },
                    { new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"), 200, 5, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://tealnotes.com/wp-content/uploads/2023/05/Featured-Image-46-800x530.png", "Eggs, salt, bell pepper, spinach", false, "Scrambled Eggs with Veggies", "Crack the eggs into a bowl, add a pinch of salt, and whisk until smooth. Heat a small amount of olive oil in a non-stick skillet over medium heat. Add diced bell pepper and cook for 2-3 minutes until softened. Add the spinach and cook until wilted, about 1 minute. Pour the eggs into the pan and gently stir with a spatula, folding the eggs over themselves until just set. Remove from heat while the eggs are still slightly soft. Serve hot, garnished with fresh herbs if desired.", 12, null },
                    { new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"), 200, 10, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0, "https://www.sweetashoney.co/wp-content/uploads/Zucchini-Noodles-With-Pesto-2-1.jpg", "Zucchini, pesto, cherry tomatoes, olive oil", false, "Zucchini Noodles with Pesto", "Spiralize zucchini into noodles. In a skillet, heat olive oil over medium heat and add zucchini noodles, cooking for 2-3 minutes until slightly softened. Stir in pesto and halved cherry tomatoes. Cook for an additional 2 minutes. Serve warm.", 5, null },
                    { new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"), 400, 8, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 0, "https://saltpepperskillet.com/wp-content/uploads/oven-baked-salmon-on-sheet-pan-horizontal-1.jpg", "Salmon fillet, lemon, herbs, asparagus", false, "Baked Salmon", "Preheat the oven to 400°F (200°C). Place the salmon fillet on a baking sheet lined with parchment paper. Squeeze fresh lemon juice over the top and sprinkle with herbs like dill or parsley. Arrange asparagus around the salmon and drizzle with olive oil. Bake for about 15-20 minutes until the salmon is cooked through and flakes easily with a fork. Serve warm with a side of your choice.", 40, null },
                    { new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"), 350, 30, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://onebalancedlife.com/wp-content/uploads/2020/08/Breakfast-Wrap-scaled-720x720.jpg", "Eggs, spinach, whole wheat wrap, cheese", false, "Egg and Spinach Breakfast Wrap", "Whisk the eggs in a bowl. In a skillet, cook spinach until wilted. Add eggs and cook, stirring gently. Place the egg and spinach mixture on a whole wheat wrap, sprinkle with cheese, and roll tightly. Serve warm.", 25, null },
                    { new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"), 300, 30, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, "https://www.nutritiousdeliciousness.com/wp-content/uploads/2024/02/Asian-Shrimp-Tacos1.jpg", "Shrimp, corn tortillas, cabbage, lime", false, "Shrimp Tacos", "Season shrimp with salt and pepper. In a skillet, cook shrimp over medium heat until pink, about 2-3 minutes per side. Warm corn tortillas in a separate pan. Assemble tacos by placing shrimp on tortillas, topping with shredded cabbage, and squeezing lime juice over them.", 25, null },
                    { new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"), 300, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, "https://heavenlyhomecooking.com/wp-content/uploads/2021/04/Vegetable-Omelette-Recipe-Featured-1.jpg", "Eggs, bell peppers, cheese, spinach", false, "Veggie Omelette", "Whisk the eggs in a bowl and season with salt and pepper. Heat a non-stick skillet over medium heat and add a little oil. Pour in the eggs and let them cook for about 1-2 minutes until the edges start to set. Add diced bell peppers and cheese on one half of the omelette. Carefully fold the other half over the filling and cook for another minute until the cheese melts and the eggs are fully cooked. Serve hot with a side of toast or fresh fruit.", 18, null },
                    { new Guid("816b8eec-5ff7-408e-a903-55f509b97302"), 450, 10, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2, "https://www.lecremedelacrumb.com/wp-content/uploads/2019/04/sheet-pan-salmon-potatoes-asparagus-1-3.jpg", "Salmon fillet, asparagus, olive oil, lemon", false, "Baked Salmon with Asparagus", "Preheat oven to 400°F (200°C). Place salmon and asparagus on a baking sheet. Drizzle with olive oil, lemon juice, salt, and pepper. Bake for 15-20 minutes until salmon is cooked through and asparagus is tender.", 40, null },
                    { new Guid("8e22c1d5-0c6e-47c7-bc25-559518fe4f24"), 200, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, "https://littlespoonfarm.com/wp-content/uploads/2021/08/tuna-salad-recipe-card.jpg", "Canned tuna, mayo, celery, lettuce", false, "Tuna Salad", "In a bowl, mix drained canned tuna with a tablespoon of mayo and diced celery. Season with salt and pepper to taste. Place a scoop of the tuna mixture on a bed of fresh lettuce leaves. You can also add diced tomatoes or cucumbers for extra crunch. Serve cold as a quick lunch or snack.", 25, null },
                    { new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281"), 200, 15, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, "https://www.kitchensanctuary.com/wp-content/uploads/2020/09/Cauliflower-Egg-Fried-Rice-square-FS-14.jpg", "Cauliflower, peas, carrots, soy sauce", false, "Cauliflower Fried Rice", "Grate cauliflower to create rice-sized pieces. In a skillet, heat oil and sauté peas and carrots until tender. Add cauliflower rice and soy sauce. Cook for 5-7 minutes, stirring frequently. Serve hot.", 5, null },
                    { new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1"), 400, 52, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 0, "https://www.simplyrecipes.com/thmb/gjS-FSuYnqK3fclkE2fWhYl1VWQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Simply-Recipes-Spaghetti-Aglio-e-Olio-LEAD-2-c8e7e8c6edb04a8691463c6ea8cd4ba1.jpg", "Spaghetti, garlic, olive oil, red pepper flakes", false, "Spaghetti Aglio e Olio", "Cook spaghetti according to package instructions. In a skillet, heat olive oil over medium heat, and add thinly sliced garlic. Sauté until golden. Add red pepper flakes and drained spaghetti. Toss to coat and serve immediately.", 12, null },
                    { new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"), 350, 20, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, "https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2021/05/Chicken-Stir-Fry-main-1.jpg", "Chicken breast, mixed vegetables, soy sauce, ginger", false, "Chicken Stir-Fry", "In a skillet, heat oil over medium-high heat. Add diced chicken breast and cook until browned. Add mixed vegetables and ginger. Stir-fry for 5-7 minutes, then add soy sauce and cook for another 2 minutes. Serve hot.", 30, null },
                    { new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a"), 300, 20, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, "https://www.foodiecrush.com/wp-content/uploads/2016/08/Linguine-and-Zucchini-Noodles-with-Shrimp-foodiecrush.com-0014.jpg", "Zucchini, shrimp, garlic, olive oil, cherry tomatoes, parsley, salt, pepper", false, "Zucchini Noodles with Grilled Shrimp", "1. Use a spiralizer to turn 2 zucchinis into noodles. Set aside. 2. Season the shrimp with salt, pepper, and a minced garlic clove. 3. Heat 1 tablespoon of olive oil in a skillet over medium heat, then add the shrimp. Cook for 2-3 minutes per side until pink and opaque. Remove from the skillet and set aside. 4. In the same skillet, add more garlic and sauté until fragrant. 5. Add the zucchini noodles and cherry tomatoes, cooking for 2-3 minutes until slightly softened. 6. Return the shrimp to the skillet, toss with the noodles, and garnish with chopped parsley. Serve warm.", 25, null },
                    { new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e"), 150, 3, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, "https://images.eatthismuch.com/img/906792_tabitharwheeler_7ecdcbb2-52e2-456d-8c38-4194febe4830.jpg", "Egg whites, spinach, bell pepper, olive oil, salt, pepper", false, "Egg White Omelet with Spinach", "1. Whisk together 4 egg whites with a pinch of salt and pepper. 2. Heat 1 teaspoon of olive oil in a non-stick skillet over medium heat. 3. Add a handful of spinach and diced bell pepper to the skillet, cooking until the spinach wilts. 4. Pour the egg whites over the vegetables and cook for 2-3 minutes until the bottom sets. 5. Carefully fold the omelet in half and cook for another minute. 6. Slide the omelet onto a plate and serve immediately.", 20, null },
                    { new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"), 500, 30, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, "https://www.rachelcooks.com/wp-content/uploads/2022/09/Beef-Stir-Fry-with-Vegetables016-web-square.jpg", "Beef, bell peppers, onions, soy sauce", false, "Beef Stir-Fry", "Slice the beef thinly across the grain and season it with a pinch of salt and pepper. Heat a tablespoon of oil in a large skillet over medium-high heat. Add the beef and cook for 3-4 minutes until browned. Remove the beef and set aside. In the same skillet, add the sliced bell peppers and onions, cooking for about 5 minutes until tender. Add the beef back to the skillet along with soy sauce and a touch of honey or brown sugar for sweetness. Stir everything together and cook for another 2 minutes. Serve hot over rice or noodles.", 40, null },
                    { new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"), 300, 10, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, "https://tastythin.com/wp-content/uploads/2020/02/asian-turkey-lettuce-wraps2-500x500.jpg", "Ground turkey, lettuce, tomatoes, avocado", false, "Turkey Lettuce Wraps", "In a skillet over medium heat, cook the ground turkey until browned, breaking it up with a spoon as it cooks. Season with salt, pepper, and a dash of cumin if desired. Wash and dry large lettuce leaves, which will serve as the wraps. Once the turkey is cooked through, spoon it into each lettuce leaf and top with diced tomatoes and sliced avocado. Serve immediately for a low-carb, high-protein meal.", 28, null },
                    { new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294"), 250, 35, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, "https://www.nospoonnecessary.com/wp-content/uploads/2020/03/Beans-for-Tacos-recipe.jpg", "Black beans, corn tortillas, avocado, salsa", false, "Black Bean Tacos", "In a bowl, mash black beans and season with lime juice. Warm corn tortillas in a skillet. Assemble tacos by filling tortillas with black bean mixture, diced avocado, and salsa. Serve with lime wedges.", 10, null },
                    { new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"), 300, 45, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 0, "https://images.getrecipekit.com/20230919180123-greek-20yogurt-20parfait.png?aspect_ratio=1:1&quality=90&", "Greek yogurt, berries, honey, granola", false, "Greek Yogurt Parfait", "In a glass or bowl, start by adding a layer of Greek yogurt at the bottom. Next, add a layer of fresh berries like strawberries, blueberries, or raspberries. Drizzle a teaspoon of honey over the berries to add a touch of sweetness. Add a layer of granola for crunch. Repeat the layers until the glass or bowl is filled, finishing with a few berries and a final drizzle of honey on top. Serve immediately for a refreshing and protein-packed breakfast or snack.", 15, null },
                    { new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"), 400, 50, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_4:3/k%2FPhoto%2FRecipes%2F2019-11-recipe-mediterranean-quinoa-salad%2F2019-10-21_Kitchn89095_Mediteranean-Quinoa-Salad", "Quinoa, cherry tomatoes, cucumber, feta cheese", false, "Quinoa Salad", "Cook quinoa according to package instructions. In a bowl, combine cooked quinoa, halved cherry tomatoes, diced cucumber, and crumbled feta cheese. Drizzle with olive oil and lemon juice, then toss to combine.", 12, null },
                    { new Guid("c670818c-d46f-440b-9332-0f0d01937887"), 400, 35, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 0, "https://mojo.generalmills.com/api/public/content/wD6Zdi1fS0OIerKfD62IBA_webp_base.webp?v=baa249d0&t=191ddcab8d1c415fa10fa00a14351227", "Bell peppers, ground beef, rice, cheese", false, "Stuffed Peppers", "Preheat the oven to 375°F (190°C). Slice the tops off the bell peppers and remove the seeds. In a skillet, brown the ground beef over medium heat. Mix in cooked rice and season with salt, pepper, and Italian herbs. Stuff the mixture into each bell pepper and place them in a baking dish. Top with shredded cheese and bake for about 25-30 minutes until the peppers are tender and the cheese is bubbly.", 25, null },
                    { new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"), 250, 30, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/1D1F8AE8-0888-45CB-B21B-15377ADC6C9A/Derivates/874a16dd-d1b1-4db0-bc13-fab251938451.jpg", "Protein powder, almond milk, banana, spinach", false, "Protein Smoothie", "In a blender, add one scoop of protein powder, a cup of almond milk, a ripe banana, and a handful of fresh spinach leaves. Blend on high until the mixture is completely smooth and no chunks remain. Taste the smoothie and add a bit of honey if you want extra sweetness. For a colder smoothie, you can add a few ice cubes or use a frozen banana. Pour into a glass and enjoy immediately for a nutritious breakfast or post-workout snack.", 20, null },
                    { new Guid("d2155f29-4a5a-4e71-a1ef-cb493b45bc4d"), 500, 70, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, "https://thestayathomechef.com/wp-content/uploads/2021/01/Mediterranean-Chickpea-Salad-1-1200x720.jpg", "Chickpeas, brown rice, cucumber, tahini", false, "Mediterranean Chickpea Bowl", "Cook brown rice according to package instructions. In a bowl, combine cooked rice, chickpeas, diced cucumber, and a drizzle of tahini. Top with lemon juice and fresh parsley.", 20, null },
                    { new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"), 450, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 1, "https://img.chefkoch-cdn.de/rezepte/1578671265353584/bilder/1509269/crop-960x540/chili-con-carne.jpg", "Ground beef, kidney beans, tomatoes, chili powder", false, "Chili Con Carne", "In a pot, brown ground beef over medium heat. Add diced tomatoes, kidney beans, and chili powder. Simmer for 30 minutes, stirring occasionally. Serve hot, garnished with chopped cilantro or cheese.", 30, null },
                    { new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"), 450, 65, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://cdn.loveandlemons.com/wp-content/uploads/2023/05/quinoa-bowl-recipe.jpg", "Quinoa, black beans, corn, avocado, lime", false, "Quinoa Bowl", "Cook quinoa according to package instructions. In a large bowl, combine cooked quinoa, rinsed black beans, corn, and diced avocado. Squeeze fresh lime juice over the top and toss gently to combine. Season with salt and pepper to taste. For added flavor, you can also add chopped cilantro or diced jalapeño. Serve chilled or at room temperature as a nutritious and filling meal.", 15, null },
                    { new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"), 250, 30, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, "https://cdn.loveandlemons.com/wp-content/uploads/2023/05/chickpea-salad-500x500.jpg", "Chickpeas, cucumber, tomatoes, lemon, olive oil", false, "Chickpea Salad", "In a bowl, combine drained chickpeas, diced cucumber, and chopped tomatoes. Drizzle with lemon juice and olive oil, and season with salt and pepper. Toss everything together until well mixed. This salad can be served immediately or chilled for a refreshing side dish or light meal.", 12, null },
                    { new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"), 350, 12, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "https://www.thespruceeats.com/thmb/1HuTabE4tSdTe8YDcdiR2ts2P3Y=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/california-grilled-chicken-salad-recipe-334159-13-8ecd934fee5e42f8b5d38239b083460b.jpg", "Chicken breast, lettuce, cucumber, tomatoes, olive oil", false, "Grilled Chicken Salad", "Season the chicken breast with salt, pepper, and a bit of garlic powder. Heat a grill pan over medium heat and cook the chicken breast for 6-7 minutes on each side, until fully cooked. Let the chicken cool slightly, then slice it thinly. In a large bowl, combine chopped lettuce, cucumber, and tomatoes. Drizzle with olive oil and toss to coat. Top with sliced chicken and serve with a light vinaigrette or dressing of your choice.", 35, null },
                    { new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"), 480, 40, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0, "https://tastesbetterfromscratch.com/wp-content/uploads/2014/03/Chicken-Bacon-Avocado-Wrap-1.jpg", "Grilled chicken breast, whole wheat wrap, avocado, tomato, lettuce, Greek yogurt", false, "Chicken Avocado Wrap", "1. Slice the grilled chicken breast into thin strips. 2. Warm the whole wheat wrap in a dry skillet over medium heat for 1-2 minutes on each side. 3. While the wrap warms, peel and mash 1/2 avocado in a bowl until smooth. 4. Spread a thin layer of Greek yogurt onto the center of the warm wrap. 5. Add the sliced chicken, mashed avocado, tomato slices, and a handful of lettuce. 6. Season with salt and pepper to taste. 7. Fold the bottom of the wrap up, then roll tightly from one side to the other. 8. Cut in half and enjoy immediately.", 30, null },
                    { new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"), 200, 25, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, "https://simple-veganista.com/wp-content/uploads/2017/04/chocolate-chia-pudding-1.jpg", "Chia seeds, almond milk, cocoa powder, honey", false, "Chocolate Chia Pudding", "In a bowl, mix chia seeds, cocoa powder, and almond milk. Stir well to combine and ensure there are no clumps. Add honey for sweetness. Cover and refrigerate for at least 4 hours or overnight until it thickens. Serve chilled, topped with fruit or nuts.", 5, null },
                    { new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"), 200, 32, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 0, "https://www.kitchensanctuary.com/wp-content/uploads/2021/10/Sweet-Potato-Fries-wideFS-20.webp", "Sweet potatoes, olive oil, salt, pepper", false, "Sweet Potato Fries", "Preheat the oven to 425°F (220°C). Cut sweet potatoes into thin strips and place them in a bowl. Drizzle with olive oil, salt, and pepper, and toss to coat evenly. Spread the sweet potatoes on a baking sheet lined with parchment paper in a single layer. Bake for 20-25 minutes until they are crispy and golden, flipping halfway through. Serve hot as a side dish or snack.", 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("816b8eec-5ff7-408e-a903-55f509b97302"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("8e22c1d5-0c6e-47c7-bc25-559518fe4f24"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("90f40e3b-b5eb-4899-b365-d4a2f94f1281"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a0e4a4a4-4b43-48b7-9173-f84a3f1d52a1"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a6c8d4e0-1c8f-4f1b-b0c2-6a6d9a7a1f2a"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a7f2e8d4-8b2e-41e8-90d7-5e2e6b7a2f5e"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a823fb5b-9ed5-4d90-9c31-2398dcdb78de"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ab237e7b-08f2-4dcd-b6f9-98a65c96f6ec"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("af3f84d1-9f18-4c65-bb8c-04d15c9e2294"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c670818c-d46f-440b-9332-0f0d01937887"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ce451c31-e002-4e97-9140-dc81837b58a7"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d2155f29-4a5a-4e71-a1ef-cb493b45bc4d"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ef63dc7f-bb29-4c6c-bcf5-4732ab2f4921"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Diets");
        }
    }
}
