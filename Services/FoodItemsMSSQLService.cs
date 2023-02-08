using System;
namespace FoodIntakeServices.Services;

using System.Collections.Generic;
using FoodIntakeServices.Interfaces;
using FoodIntakeServices.Models;
using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Data;

public class FoodItemsMSSQLService : IFoodItemsService
{
    private readonly DataContext _dataContext;
    private readonly IUsersService _userService;

    public FoodItemsMSSQLService(DataContext dataContext, IUsersService usersService)
    {
        _dataContext = dataContext;
        _userService = usersService;
    }
    public FoodItem Delete(int id)
    {
        FoodItem food = _dataContext.FoodItems.FirstOrDefault(f => f.Id == id);
        _dataContext.FoodItems.Remove(food);
        return food;
    }

    public List<FoodItem> GetAll()
    {
        // return _dataContext.FoodItems.ToList<FoodItem>();
        List<FoodItem> foodItem = _dataContext.FoodItems.ToList<FoodItem>();
        foreach (FoodItem food in foodItem)
        {
            food.User = _userService.GetById(food.UserId);
        }
        return foodItem;
    }

    // public List<FoodItem> GetByDate(DateTime date)
    // {
    //     List<FoodItem> newFoodItem = new List<FoodItem>();
    //     List<FoodItem> foodItem = _dataContext.FoodItems.ToList<FoodItem>();
    //     foreach (FoodItem food in foodItem)
    //     {
    //         if (food.DateEaten.Date == date.Date)
    //         {
    //             newFoodItem.Add(food);
    //         }
    //     }
    //     return newFoodItem;
    // }

    public FoodItem GetById(int id)
    {
        return _dataContext.FoodItems.SingleOrDefault((o) => o.Id == id);
    }

    public FoodItem GetByIdAndUserId(int id, int userId)
    {
        User user = _userService.GetById(userId);
        FoodItem food = _dataContext.FoodItems.SingleOrDefault((food) => food.Id == id);
        food.User = user;
        return food;
    }


    public void Save(FoodItem hash)
    {
        if (hash.Id == null || hash.Id == 0)
        {
            _dataContext.FoodItems.Add(hash);
        }
        else
        {
            FoodItem temp = this.GetById(hash.Id);
            temp.Meal = hash.Meal;
            temp.Name = hash.Meal;
            temp.Calorie = hash.Calorie;
            temp.Quantity = hash.Quantity;
            temp.Measure = hash.Measure;
            temp.DateEaten = hash.DateEaten;
            temp.CreatedOn = hash.CreatedOn;
            temp.CreatedBy = hash.CreatedBy;
            temp.LastUpdatedOn = hash.LastUpdatedOn;
            temp.LastUpdatedBy = hash.LastUpdatedBy;
            temp.IsActive = hash.IsActive;
            temp.IsNotEditable = hash.IsNotEditable;
            temp.UserId = hash.UserId;
        }
        _dataContext.SaveChanges();
    }

    public void Edit(FoodItem hash, int id)
    {

        FoodItem temp = this.GetById(hash.Id);
        temp.Meal = hash.Meal;
        temp.Name = hash.Meal;
        temp.Calorie = hash.Calorie;
        temp.Quantity = hash.Quantity;
        temp.Measure = hash.Measure;
        temp.DateEaten = hash.DateEaten;
        temp.CreatedOn = hash.CreatedOn;
        temp.CreatedBy = hash.CreatedBy;
        temp.LastUpdatedOn = hash.LastUpdatedOn;
        temp.LastUpdatedBy = hash.LastUpdatedBy;
        temp.IsActive = hash.IsActive;
        temp.IsNotEditable = hash.IsNotEditable;
        temp.UserId = hash.UserId;

        _dataContext.SaveChanges();
    }


}
