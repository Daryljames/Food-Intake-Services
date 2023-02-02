namespace FoodIntakeServices.Configuration;

using FoodIntakeServices.Models;

public class ApplicationContext
{
    public List<FoodItem> foodItems;

    private static ApplicationContext instance = null;

    public static ApplicationContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ApplicationContext();
            }
            return instance;
        }
    }

    public ApplicationContext()
    {
        this.foodItems = new List<FoodItem>();
        FoodItem foodItem1 = new FoodItem { Id = 1, Name = "egg", Calorie = 100 };
        FoodItem foodItem2 = new FoodItem { Id = 2, Name = "rice", Calorie = 120 };

        foodItems.Add(foodItem1);
        foodItems.Add(foodItem2);
    }
}