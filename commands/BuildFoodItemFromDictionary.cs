using FoodIntakeServices.Models;
using System.Text.Json;

namespace FoodIntakeServices.Commands
{
    public class BuildFoodItemFromDictionary
    {
        private Dictionary<string, object> data;

        public BuildFoodItemFromDictionary(Dictionary<string, object> data)
        {
            this.data = data;
        }

        public FoodItem Execute()
        {
            FoodItem foodItem = new FoodItem();

            if (data.ContainsKey("id"))
            {
                foodItem.Id = int.Parse(this.data["id"].ToString());
            }

            foodItem.Meal = this.data["meal"].ToString();
            foodItem.Name = this.data["name"].ToString();
            foodItem.Calorie = float.Parse(this.data["calorie"].ToString());
            foodItem.Quantity = float.Parse(this.data["quantity"].ToString());
            foodItem.Measure = this.data["measure"].ToString();
            foodItem.DateEaten = DateOnly.Parse(this.data["dateEaten"].ToString());
            foodItem.CreatedOn = DateTime.Parse(this.data["createdOn"].ToString());
            foodItem.CreatedBy = this.data["createdBy"].ToString();
            foodItem.LastUpdatedOn = DateTime.Parse(this.data["lastUpdatedOn"].ToString());
            foodItem.LastUpdatedBy = this.data["lastUpdatedBy"].ToString();
            foodItem.IsActive = bool.Parse(this.data["isActive"].ToString());

            return foodItem;
        }
    }
}