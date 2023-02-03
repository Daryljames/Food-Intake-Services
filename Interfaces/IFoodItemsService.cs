namespace FoodIntakeServices.Interfaces;

using FoodIntakeServices.Models;

public interface IFoodItemsService
{
    public List<FoodItem> GetAll();

    public void Save(FoodItem hash);

    public FoodItem GetById(int id);

    public FoodItem Delete(int id);
}