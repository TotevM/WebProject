using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("1c6e0b2a-3b6a-4427-8df7-51d8a9f2a9a3"),
                column: "ImageUrl",
                value: "https://physiotutors.com/wp-content/uploads/2022/01/Seated-Leg-Extension-featured.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("1e5b9a3c-2d8e-4c7d-9d3e-4d8f2c3e1b6f"),
                column: "ImageUrl",
                value: "https://i.ytimg.com/vi/oIgci8aNsG0/maxresdefault.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("29d3278f-fb37-45a8-a7b6-41e6636e2e02"),
                column: "ImageUrl",
                value: "https://rockrun.com/cdn/shop/articles/859664_1600x.jpg?v=1585560306");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("2a8ed1d9-84d3-4fd4-83e2-2c4391f0b01b"),
                column: "ImageUrl",
                value: "https://www.trainheroic.com/wp-content/uploads/2023/02/AdobeStock_271990601-TH-jpg.webp");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3e6c1f4b-0e5d-4f8d-8b2b-1a0e37dce9b7"),
                column: "ImageUrl",
                value: "https://www.jefit.com/images/exercises/960_590/4944.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3e9a5c5f-8d7e-4b2c-923b-27c4a6e2a6d7"),
                column: "ImageUrl",
                value: "https://media1.popsugar-assets.com/files/thumbor/wt7_DSw2I9cf_vui75Wo9K_nu_k=/fit-in/792x792/filters:format_auto():quality(70):extract_cover():upscale()/2024/03/13/886/n/1922729/tmp_rwtOqh_ab899a86a9ca6d73_PS23_Fitness_Workout_07_Move_08_Step_Up_v2.gif");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("4e8b7a3b-e5c1-4c73-95ab-27a05dcf2a31"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/seated-cable-row.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("69b1df3e-1e34-44f3-8e3b-dca7eb9b2f3f"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/dumbbell-fly.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8c1e5b-0e6d-4b8d-8d2f-2a1e3c7dce8d"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/seated-overhead-dumbbell-tricep-extension_0.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("8c3d6a7b-e1f2-4c3b-9d3e-0e3c4f5a1b2d"),
                column: "ImageUrl",
                value: "https://www.dmoose.com/cdn/shop/articles/1_155d781f-a698-40e7-bdb6-f0de019f9b89.jpg?v=1648738774");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("96d3e1b7-7806-4f54-bc58-5d8b9d8a7f1f"),
                column: "ImageUrl",
                value: "https://hips.hearstapps.com/hmg-prod/images/hammer-curls-1581441441.jpg?crop=0.668xw:1.00xh");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9b8de205-3c91-47f8-a6bc-46a6d2c48238"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/t-bar-row.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ab4c987e-6444-4c3f-b967-1ec2ffce9bd9"),
                column: "ImageUrl",
                value: "https://fitnessvolt.com/wp-content/uploads/2021/09/Female-bodyweight-squat-750x549.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b6a7ecb8-5e4e-4372-8d6d-f63b0c6e639e"),
                column: "ImageUrl",
                value: "https://www.newbodyplan.co.uk/wp-content/uploads/2022/01/pec-deck-chest-machine-flye-pectorals-man-gym-weight-training.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b7c4a2b9-dfb2-4b6e-b7f7-58b5d33a0f34"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/field/feature-image/workout/guns-a-blazing-feature.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b9c7e1d7-a9b2-4505-89c9-6cf8d87e2e6d"),
                column: "ImageUrl",
                value: "https://images.healthshots.com/healthshots/en/uploads/2024/05/02174153/Lunges.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bfc4e908-2f9f-4f2f-99bb-a1d462eae20f"),
                column: "ImageUrl",
                value: "https://cdn.mos.cms.futurecdn.net/9ghCpUY6JaLtStkZkeH73T-1200-80.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("c9b4f5f1-1e3d-4a93-9d42-bb27a1b4b315"),
                column: "ImageUrl",
                value: "https://ironbullstrength.com/cdn/shop/articles/leg_press_knee_pain.webp?v=1695829075");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("cce872f8-19f8-4e7d-bd57-e7f5c66a06b7"),
                column: "ImageUrl",
                value: "https://www.barbellmedicine.com/wp-content/uploads/2023/10/The-Bench-Press.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ccf2748a-492e-496e-bd6b-8df2dc9b8f4a"),
                column: "ImageUrl",
                value: "https://d1lcvt77zgh63s.cloudfront.net/wp-content/uploads/2023/09/barbell-bent-over-row.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("d3e0b5f7-a1b5-4207-81b3-e0a5f6e0e8b5"),
                column: "ImageUrl",
                value: "https://media.self.com/photos/5c5b6d8f8f8b702d129df281/master/pass/woman-lunging-gym.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("d4f5b8b7-5638-4882-9254-07f5f35c09d6"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/lat-pull-down.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("db8d4f5e-3f5f-4bfe-9b53-8171b4c77f8b"),
                column: "ImageUrl",
                value: "https://uk.gymreapers.com/cdn/shop/articles/wearing_a_lifting_belt_for_deadlifts.png?v=1675261258&width=1500");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("dbb7b1c4-72e8-4a37-91a7-fb97d4b4f0e3"),
                column: "ImageUrl",
                value: "https://www.tonal.com/wp-content/uploads/2024/01/Bulgarian-Split-Squat-Hero.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("e2b1f3f7-8c1e-4b5f-9f2a-0e3c7d5b0d8d"),
                column: "ImageUrl",
                value: "https://mirafit.co.uk/wp/wp-content/uploads/2023/12/skull-crusher-using-Mirafit-EZ-Curl-Bar-1024x683.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("f2c3d8a4-b1e8-4d2f-9c3e-4d8f2e3c1b0d"),
                column: "ImageUrl",
                value: "https://www.borntough.com/cdn/shop/articles/Best_Biceps_Cable_Curls_Variations_and_Workouts.jpg?v=1655822555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("fd3e8bc1-a4a6-4535-91f9-e4e68e0cde90"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/seated-concentration-curl.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("fdcd4903-8d91-4091-91de-96b88b0a5f23"),
                column: "ImageUrl",
                value: "https://cdn.muscleandstrength.com/sites/default/files/incline-bench-press.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ff5e9f1a-8f9f-4a8f-9081-d17b9e6fbe3c"),
                column: "ImageUrl",
                value: "https://steelsupplements.com/cdn/shop/articles/shutterstock_1705063531_1000x.jpg?v=1642058677");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Exercises");
        }
    }
}
