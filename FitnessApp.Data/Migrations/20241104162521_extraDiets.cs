using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class extraDiets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"));

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "Calories", "Carbohydrates", "CreatedOn", "Description", "Fats", "ImageUrl", "Name", "Protein", "UserID" },
                values: new object[,]
                {
                    { new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rich in fruits, vegetables, whole grains, and healthy fats.", 0, "https://imgs.search.brave.com/XMqYsLggsYc1O09i-aEGhJO-TlIABgiyisJeNCe1RzE/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/aGVhcnQub3JnLy0v/bWVkaWEvQUhBL0g0/R00vQXJ0aWNsZS1J/bWFnZXMvTWVkaXRl/cnJhbmVhbl9EaWV0/LmpwZw", "Mediterranean Diet", 0, null },
                    { new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A well-balanced diet for healthy living.", 0, "https://imgs.search.brave.com/s8CFdPvLm2v8QBJZdmM9JTjyexe9YWX3kQMEu26T0FI/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/cHJlbWl1bS1waG90/by93ZWxsLWJhbGFu/Y2VkLXBsYXRlLWZv/b2QtZmVhdHVyaW5n/LWxlYW4tcHJvdGVp/bnMtaGVhbHRoeS1l/YXRpbmctY2hvaWNl/c184OTM1NzEtNjY1/MDIuanBnP3NlbXQ9/YWlzX2h5YnJpZA", "Balanced Diet", 0, null },
                    { new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A low-carb diet to promote weight loss.", 0, "https://tasteforlife.com/sites/default/files/styles/laptop/public/diet-nutrition/special-diets/low-carb-diets-for-health-benefits/low-carb-diets-for-health-benefits.jpg?itok=saTbKWSP", "Low-Carb Diet", 0, null },
                    { new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dietary Approaches to Stop Hypertension; focuses on lowering blood pressure.", 0, "https://imgs.search.brave.com/W8_zgv8MUFPLIzugGECfKg3eilSWZNWVYu5m_RMcy7U/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9oaXBz/LmhlYXJzdGFwcHMu/Y29tL2htZy1wcm9k/L2ltYWdlcy9mb29k/cy1pdGVtcy1oaWdo/LWluLWhlYWx0aHkt/b21lZ2EtMy1mYXRz/LXJveWFsdHktZnJl/ZS1", "DASH Diet", 0, null },
                    { new Guid("b9945d16-9964-4897-acba-2846f8730292"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ideal for muscle growth and recovery.", 0, "https://imgs.search.brave.com/nFLS8O8iqyEsTxAc25VNTBCwWxqg_TGi_X-RsVNVqck/rs:fit:860:0:0:0/g:ce/aHR0cDovL2NvbnRl/bnQuaGVhbHRoLmhh/cnZhcmQuZWR1L3dw/LWNvbnRlbnQvdXBs/b2Fkcy8yMDI0LzAx/LzI4ZThlNDY0LWY1/NWUtNGIzMi05YmFi/LWRjOTkwZDhjYzky/Ny5qcGc", "High-Protein Diet", 0, null },
                    { new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-fat, low-carb diet that aims to induce ketosis.", 0, "https://imgs.search.brave.com/La-R_B0imoy5SP6j0f1AFv1eM1NgGMmWg5yN9IczNEo/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTEz/Mzc5NDIyMS9waG90/by9oZWFsdGh5LWtl/dG8tYnJlYWtmYXN0/LWVnZy1hdm9jYWRv/LWNoZWVzZS1iYWNv/bi5qcGc_cz02MTJ4/NjEyJnc9MCZrPTIw/JmM9eVV6QnJJaUxO/a2NiOHFhVXRldEJO/LVVCQXQ1OGtVWjN6/amlkZ2UtR253OD0", "Keto Diet", 0, null },
                    { new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A plant-based diet that excludes all animal products.", 0, "https://imgs.search.brave.com/xOEfQ19UaCLOKXzo-5Jbb4nLcKwO9UbBo5wewTvTJXw/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMuaW1tZWRpYXRl/LmNvLnVrL3Byb2R1/Y3Rpb24vdm9sYXRp/bGUvc2l0ZXMvMzAv/MjAyNC8wNi9IZWFs/dGh5LXZlZ2FuNzAw/LWU2YzJiNWUuanBn/P3F1YWxpdHk9OTAm/Zml0PTcwMCwzNTA", "Vegan Diet", 0, null },
                    { new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Focuses on whole foods similar to what might have been eaten in the Paleolithic era.", 0, "https://imgs.search.brave.com/3oOdIC1IaTHXOsjmkwIhQCtX9QNDaBkJUo_hAxv1Xjg/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9hc3Nl/dHMuY2xldmVsYW5k/Y2xpbmljLm9yZy90/cmFuc2Zvcm0vTGFy/Z2VGZWF0dXJlSW1h/Z2UvZWJiZDhjMGYt/OTcwOS00YjFkLWJk/OTktZTNlMzE1MWYw/ZTNhL1BhbGVvLURp/ZXQtMTMwMTU2NTM3/NS03NzB4NTMzLTFf/anBn", "Paleo Diet", 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("042a990d-b389-4a3b-8c3e-f9958eecb5ba"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4003ee86-9566-4dd5-ab03-be63572904a3"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("4bf17f5e-3c9e-444c-bc03-11ba09df4844"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("932d7750-8a1e-40de-a10e-a3b44592844f"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("b9945d16-9964-4897-acba-2846f8730292"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("c72e4c43-14c9-4646-ba9d-9f632141572d"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("d8540959-108c-4a29-b1f2-e475f469b95c"));

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: new Guid("e38bbd08-712c-455d-aa59-83ad83b1ccec"));

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "Calories", "Carbohydrates", "CreatedOn", "Description", "Fats", "ImageUrl", "Name", "Protein", "UserID" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A well-balanced diet for healthy living.", 0, null, "Balanced Diet", 0, null },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0de1-f2a3b4c5d6e7"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ideal for muscle growth and recovery.", 0, null, "High-Protein Diet", 0, null },
                    { new Guid("3c4d5e6f-7a8b-9c0d-e1f2-3a4b5c6d7e8f"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A low-carb diet to promote weight loss.", 0, "https://tasteforlife.com/sites/default/files/styles/laptop/public/diet-nutrition/special-diets/low-carb-diets-for-health-benefits/low-carb-diets-for-health-benefits.jpg?itok=saTbKWSP", "Low-Carb Diet", 0, null }
                });
        }
    }
}
