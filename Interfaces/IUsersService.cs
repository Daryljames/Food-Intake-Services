namespace FoodIntakeServices.Interfaces;

using FoodIntakeServices.Models;

public interface IUsersService
{
    public List<User> GetAll();
    public User GetById(int id);

    public void Save(User hash);
}