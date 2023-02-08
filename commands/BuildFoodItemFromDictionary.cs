using FoodIntakeServices.Models;
using System.Text.Json;
using FoodIntakeServices.Interfaces;

namespace FoodIntakeServices.Commands
{
    public class BuildFoodItemFromDictionary
    {
        private Dictionary<string, object> data;

        public IUsersService _usersService;

        public BuildFoodItemFromDictionary(Dictionary<string, object> data, IUsersService usersService)
        {
            this.data = data;
            _usersService = usersService;
        }

        public FoodItem Execute()
        {
            FoodItem foodItem = new FoodItem();

            User user = new User();



            if (data.ContainsKey("id"))
            {
                foodItem.Id = int.Parse(this.data["id"].ToString());
            }

            foodItem.Meal = this.data["meal"].ToString();
            foodItem.Name = this.data["name"].ToString();
            foodItem.Calorie = float.Parse(this.data["calorie"].ToString());
            foodItem.Quantity = float.Parse(this.data["quantity"].ToString());
            foodItem.Measure = this.data["measure"].ToString();
            foodItem.DateEaten = DateTime.Parse(this.data["dateEaten"].ToString());
            foodItem.CreatedOn = DateTime.Parse(this.data["createdOn"].ToString());
            foodItem.CreatedBy = this.data["createdBy"].ToString();
            foodItem.LastUpdatedOn = DateTime.Parse(this.data["lastUpdatedOn"].ToString());
            foodItem.LastUpdatedBy = this.data["lastUpdatedBy"].ToString();
            foodItem.IsActive = bool.Parse(this.data["isActive"].ToString());
            foodItem.IsNotEditable = bool.Parse(this.data["isNotEditable"].ToString());
            foodItem.UserId = int.Parse(this.data["user"].ToString());
            System.Console.WriteLine(foodItem);

            return foodItem;
        }
    }
}