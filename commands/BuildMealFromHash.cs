using FoodIntakeServices.Models;
using System.Text.Json;

namespace FoodIntakeServices.Commands
{
    public class BuildMealFromHash
    {
        private Dictionary<string, object> data;

        public BuildMealFromHash(Dictionary<string, object> data)
        {
            this.data = data;
        }

        public Meal Execute()
        {
            Meal meal = new Meal();

            if (data.ContainsKey("id"))
            {
                meal.Id = int.Parse(this.data["id"].ToString());
            }

            meal.Name = this.data["name"].ToString();
            meal.IsActive = bool.Parse(this.data["isActive"].ToString());

            return meal;
        }
    }
}