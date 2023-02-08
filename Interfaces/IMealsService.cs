namespace FoodIntakeServices.Interfaces;

using FoodIntakeServices.Models;

public interface IMealsService
{
    public List<Meal> GetAll();

    public Meal GetById(int id);

    public void Save(Meal data);
}