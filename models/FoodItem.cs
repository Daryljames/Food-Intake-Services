namespace FoodIntakeServices.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Meal { get; set; }
        public string Name { get; set; }
        public float Calorie { get; set; }
        public float Quantity { get; set; }
        public string Measure { get; set; }
        public DateTime DateEaten { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsNotEditable { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public FoodItem()
        {

        }
    }
}