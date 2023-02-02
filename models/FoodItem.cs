namespace FoodIntakeServices.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calorie { get; set; }

        public FoodItem()
        {
            // this.Id = id;
            // this.Name = name;
            // this.Calorie = calorie;
        }
        public FoodItem(int id, string name, int calorie)
        {
            this.Id = id;
            this.Name = name;
            this.Calorie = calorie;
        }
    }
}