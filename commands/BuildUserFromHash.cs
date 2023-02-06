using FoodIntakeServices.Models;
using System.Text.Json;

namespace FoodIntakeServices.Commands
{
    public class BuildUserFromHash
    {
        private Dictionary<string, object> data;

        public BuildUserFromHash(Dictionary<string, object> data)
        {
            this.data = data;
        }

        public User Execute()
        {
            User user = new User();

            if (data.ContainsKey("id"))
            {
                user.Id = int.Parse(this.data["id"].ToString());
            }

            user.FirstName = this.data["firstName"].ToString();
            user.MiddleName = this.data["middleName"].ToString();
            user.LastName = this.data["lastName"].ToString();
            user.Age = int.Parse(this.data["age"].ToString());
            user.Weight = float.Parse(this.data["weight"].ToString());
            user.WeightType = this.data["weightType"].ToString();
            user.Height = float.Parse(this.data["height"].ToString());
            user.HeightType = this.data["heightType"].ToString();
            user.UserType = this.data["userType"].ToString();
            user.CalorieGoal = float.Parse(this.data["calorieGoal"].ToString());
            user.Email = this.data["email"].ToString();
            user.Password = this.data["password"].ToString();

            return user;
        }
    }
}