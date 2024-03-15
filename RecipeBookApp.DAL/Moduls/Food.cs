using RecipeBookApp.DAL.Moduls;

namespace Products
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? DetailsId { get; set; }
        public List<RecipeFood> RecipeFood { get; set; }
        public FoodDetails? Details { get; set; }
        public FoodType FoodType { get; set; }

    
    }
}