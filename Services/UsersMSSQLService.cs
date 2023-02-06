namespace FoodIntakeServices.Services;

using System.Collections.Generic;
using FoodIntakeServices.Interfaces;
using FoodIntakeServices.Models;
using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Data;

public class UsersMSSQLService : IUsersService
{
    private readonly DataContext _dataContext;

    public UsersMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public List<User> GetAll()
    {
        return _dataContext.Users.ToList<User>();
    }

    public User GetById(int id)
    {
        return _dataContext.Users.SingleOrDefault((o) => o.Id == id);
    }

    public void Save(User data)
    {
        if (data.Id == null || data.Id == 0)
        {
            _dataContext.Users.Add(data);
        }
        else
        {
            User temp = this.GetById(data.Id);
            temp.FirstName = data.FirstName;
            temp.MiddleName = data.MiddleName;
            temp.LastName = data.LastName;
            temp.Age = data.Age;
            temp.Weight = data.Weight;
            temp.WeightType = data.WeightType;
            temp.Height = data.Height;
            temp.HeightType = data.HeightType;
            temp.UserType = data.UserType;
            temp.CalorieGoal = data.CalorieGoal;
            temp.Email = data.Email;
            temp.Password = data.Password;
        }
        _dataContext.SaveChanges();
    }
}