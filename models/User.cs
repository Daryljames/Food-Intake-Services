namespace FoodIntakeServices.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public float Weight { get; set; }
    public string WeightType { get; set; }
    public float Height { get; set; }
    public string HeightType { get; set; }
    public string UserType { get; set; }
    public float CalorieGoal { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<FoodItem> FoodItems { get; set; }

    public User()
    {

    }

}