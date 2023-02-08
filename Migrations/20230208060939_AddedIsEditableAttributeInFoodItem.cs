using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodIntakeServices.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsEditableAttributeInFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEditable",
                table: "FoodItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEditable",
                table: "FoodItems");
        }
    }
}
