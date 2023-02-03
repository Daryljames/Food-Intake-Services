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

            this.CleanUp();
        }

        public FoodItem Execute()
        {
            FoodItem foodItem = new FoodItem();

            if (data.ContainsKey("id"))
            {
                foodItem.Id = (int)this.data["id"];
            }


            foodItem.Name = (string)this.data["name"];
            foodItem.Calorie = (int)this.data["calorie"];

            return foodItem;
        }

        public void CleanUp()
        {
            if (this.data["id"] is JsonElement)
            {
                this.data["id"] = int.Parse(((JsonElement)this.data["id"]).ToString());
            }
            if (this.data["name"] is JsonElement)
            {
                this.data["name"] = ((JsonElement)this.data["name"]).ToString();
            }
            if (this.data["calorie"] is JsonElement)
            {
                this.data["calorie"] = int.Parse(((JsonElement)this.data["calorie"]).ToString());
            }
        }
    }
}