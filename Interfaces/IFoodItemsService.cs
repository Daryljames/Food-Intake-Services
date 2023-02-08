namespace FoodIntakeServices.Interfaces;

using FoodIntakeServices.Models;

public interface IFoodItemsService
{
    public List<FoodItem> GetAll();

    public void Save(FoodItem hash);
    public void Edit(FoodItem hash, int id);

    public FoodItem GetById(int id);

    // public List<FoodItem> GetByDate(DateTime date);

    public FoodItem Delete(int id);

    public FoodItem GetByIdAndUserId(int id, int userId);
}