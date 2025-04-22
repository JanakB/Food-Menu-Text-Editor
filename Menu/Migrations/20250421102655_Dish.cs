using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Migrations
{
    /// <inheritdoc />
    public partial class Dish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeIN56Csw8LEnEIiuKKmELfFi11Hmt8sC1uQ&s");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdnyqX7qXtkCEI-UEE5TddvD7FDRkqt0ZV0w&s", "Peporoni" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQx-GQ2TMDlb3dz_N_WOMWeOBHwz5YOMBElZA&s");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQx-GQ2TMDlb3dz_N_WOMWeOBHwz5YOMBElZA&s", "ghg" });
        }
    }
}
