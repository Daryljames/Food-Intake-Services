namespace FoodIntakeServices.Configuration;

using FoodIntakeServices.Models;

public class ApplicationContext
{
    public List<FoodItem> foodItems;
    // List for all

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
        FoodItem foodItem1 = new FoodItem
        {
            Id = 1,
            Meal = "breakfast",
            Name = "egg",
            Calorie = 120.20F,
            Quantity = 1,
            Measure = "small",
            DateEaten = new DateTime(2023, 2, 03),
            CreatedOn = new DateTime(2023, 02, 03, 0, 0, 0),
            CreatedBy = "user1",
            LastUpdatedOn = new DateTime(2023, 02, 03, 0, 0, 1),
            LastUpdatedBy = "user1",
            IsActive = true,
            IsNotEditable = false
        };
        FoodItem foodItem2 = new FoodItem
        {
            Id = 2,
            Meal = "breakfast",
            Name = "rice",
            Calorie = 120.13F,
            Quantity = 1,
            Measure = "cup",
            DateEaten = new DateTime(2023, 2, 03),
            CreatedOn = new DateTime(2023, 02, 03, 0, 0, 0),
            CreatedBy = "user1",
            LastUpdatedOn = new DateTime(2023, 02, 03, 0, 0, 1),
            LastUpdatedBy = "user1",
            IsActive = true,
            IsNotEditable = false
        };

        foodItems.Add(foodItem1);
        foodItems.Add(foodItem2);
    }
}