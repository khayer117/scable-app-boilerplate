using Microsoft.EntityFrameworkCore.Migrations;

namespace Sab.DataAcess.Migrations
{
    public partial class CorrectrelationshipofSubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Products_ProductId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_ProductId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SubCategories");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId1",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryId1",
                table: "SubCategories",
                column: "SubCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_SubCategories_SubCategoryId1",
                table: "SubCategories",
                column: "SubCategoryId1",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_SubCategories_SubCategoryId1",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_SubCategoryId1",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryId1",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SubCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_ProductId",
                table: "SubCategories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Products_ProductId",
                table: "SubCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
