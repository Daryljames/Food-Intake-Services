namespace FoodIntakeServices.Services;

using System.Collections.Generic;
using FoodIntakeServices.Interfaces;
using FoodIntakeServices.Models;
using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Data;

public class MealsMSSQLService : IMealsService
{
    private readonly DataContext _dataContext;

    public MealsMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public List<Meal> GetAll()
    {
        return _dataContext.Meals.ToList<Meal>();
    }
    public Meal GetById(int id)
    {
        return _dataContext.Meals.SingleOrDefault((o) => o.Id == id);
    }

    public void Save(Meal data)
    {
        if (data.Id == null || data.Id == 0)
        {
            _dataContext.Meals.Add(data);
        }
        else
        {
            Meal temp = this.GetById(data.Id);
            temp.Name = data.Name;
            temp.IsActive = data.IsActive;
        }

        _dataContext.SaveChanges();
    }
}