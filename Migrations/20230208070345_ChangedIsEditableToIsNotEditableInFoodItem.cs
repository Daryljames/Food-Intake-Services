using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodIntakeServices.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIsEditableToIsNotEditableInFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEditable",
                table: "FoodItems",
                newName: "IsNotEditable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsNotEditable",
                table: "FoodItems",
                newName: "IsEditable");
        }
    }
}
