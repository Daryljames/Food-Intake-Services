namespace FoodIntakeServices.Services;

using System.Collections.Generic;
using FoodIntakeServices.Interfaces;
using FoodIntakeServices.Configuration;
using FoodIntakeServices.Models;

public class FoodItemsApplicationContextService : IFoodItemsService
{
    public List<FoodItem> GetAll()
    {
        return ApplicationContext.Instance.foodItems;
    }

    public void Save(FoodItem hash)
    {
        ApplicationContext.Instance.foodItems.Add(hash);
    }

    public FoodItem GetById(int id)
    {
        FoodItem food = ApplicationContext.Instance.foodItems.FirstOrDefault(i => i.Id == id);
        return food;
    }

    public FoodItem Delete(int id)
    {
        FoodItem food = ApplicationContext.Instance.foodItems.FirstOrDefault(i => i.Id == id);
        ApplicationContext.Instance.foodItems.Remove(food);
        return food;
    }

    public FoodItem GetByIdAndUserId(int id, int userId)
    {
        return ApplicationContext.Instance.foodItems.SingleOrDefault((food) => food.Id == id && food.User.Id == userId);
    }

    public void Edit(FoodItem hash, int id)
    {
        ApplicationContext.Instance.foodItems.Add(hash);
    }

    // public List<FoodItem> GetByDate(DateTime date)
    // {
    //     List<FoodItem> newFoodItem = new List<FoodItem>();
    //     List<FoodItem> foodItem = ApplicationContext.Instance.foodItems;
    //     foreach (FoodItem food in foodItem)
    //     {
    //         if (food.DateEaten.Date == date.Date)
    //         {
    //             newFoodItem.Add(food);
    //         }
    //     }
    //     return newFoodItem;
    // }
}