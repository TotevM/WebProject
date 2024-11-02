using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecipeCorrectSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c670818c-d46f-440b-9332-0f0d01937887"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"),
                column: "Goal",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("19bdb4c8-3731-4456-8e8e-5e0d174b3241"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("23d3e7f0-2d8f-4fc3-8a3a-8f9b6a6c2e93"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2995c236-5b5d-42f9-89b5-15576256ee66"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("29b2d59e-5ac9-46cd-bbb3-4b235e5bff0f"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("37df0c76-9487-4d99-9b18-f5c30c4ffcb3"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f9f14b8-bba3-4f57-b407-d4eb33c1f789"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("53fa075b-fc37-46bc-b50f-c4d60013ef7a"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("60e4a005-500e-4973-9d71-1b5c462f7de5"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("71c3c77c-e826-47c5-92d0-88c42d22b867"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7a88e34d-b5ba-4717-b1c1-5348d8d2a3ef"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a1c1a9cd-25f5-4c19-89f6-32851f0d1152"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b2175cd6-6822-4e93-917f-3e8c70c09fbc"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("be29b72f-3f75-49d0-bb69-7d1e54aab95a"),
                column: "Goal",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c670818c-d46f-440b-9332-0f0d01937887"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("dd638b57-0b70-46a7-8aeb-bf8c8025c222"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e073b44d-417e-4b9e-85d8-5a9536185b68"),
                column: "Goal",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e3f7d4b7-94b2-4b3f-889e-8d7e5cdef921"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("eb4ad19e-e048-4630-bb57-2ee9c470de79"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f3a7d8d2-1b9d-4c31-995a-6fa4fd0b032a"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff564649118"),
                column: "Goal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fb3e4329-2c05-49cc-9c19-6ff56464918b"),
                column: "Goal",
                value: 0);
        }
    }
}
