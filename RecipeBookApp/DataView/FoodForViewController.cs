using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.DataView
{
    public class FoodForViewController
    {
        public List<FoodForView> FoodForViews { get; set; }

        public FoodForViewController() 
        {

        }
        public void setFoodForViewController(List<Food> foodList) 
        {
            FoodForViews = new List<FoodForView>();
            foreach (var food in foodList)
            {
                FoodForViews.Add(new FoodForView()
                {
                    Id = food.Id,
                    Name = food.Name,
                    Type = food.FoodType
                }
                );
            }
        }


    }
}
