using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodIntakeServices.Migrations
{
    /// <inheritdoc />
    public partial class removedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Users_UserId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_UserId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_UserId",
                table: "FoodItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Users_UserId",
                table: "FoodItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
