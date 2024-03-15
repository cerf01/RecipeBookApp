using GetFoodFromApi;
using Products;
using RecipeBookApp.DAL;
using RecipeBookApp.DAL.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeBookApp.Service
{
    public  class Service
    {
        private  Repository<Food> _foodRepository;
        private  Repository<FoodDetails> _detailsRepository;
        private  Repository<Recipe> _recipeRepository;
        public Service()
        {
            _foodRepository = new Repository<Food>();
            _detailsRepository = new Repository<FoodDetails>();
            _recipeRepository = new Repository<Recipe>();
        }
        public  void AddNewFood(List<FoodFromApi> fromApi, FoodType type) 
        {
            foreach (var food in fromApi) 
            {
                var nFood = new Food() 
                {
                    Name = food.name,
                    Details = new FoodDetails
                    {
                        Calories = food.calories,
                        FatTota = food.fat_total_g,
                        Fiber = food.fiber_g,
                        Protein = food.protein_g,
                        Sugar = food.sugar_g
                    },
                FoodType = type 
                };
               _foodRepository.add(nFood);
            }
        }

        public  List<Food> GetFoodList() 
        {
            return _foodRepository.GetAll().ToList();
        }
        public  List<Recipe> GetRecipesList() 
        {
            return _recipeRepository.GetAll().ToList();
        }
        public void AddNewRecipe(List<string> ingredientList, string dishName, string description) 
        {
            var ingredients = new List<Food>();
            foreach (var ingredient in ingredientList)
            {
                ingredients
                    .Add(
                        _foodRepository
                            .Get
                            (
                                _foodRepository
                                .GetAll()
                                .Where(f => f.Name == ingredient)
                                .First()
                                .Id
                            )
                        );
            }

            var recipe = new Recipe() 
            {
                Name = dishName,
                Description = description,
                AddetAt = DateTime.Now
            };
            List<RecipeFood> recipeFood = new List<RecipeFood>();
            for (int i = 0; i < ingredients.Count();i++)
            {
                recipeFood.Add(new RecipeFood() { Recipe = recipe, FoodId = ingredients[i].Id });
            }
            recipe.RecipeFood = recipeFood;
            MessageBox.Show(recipe.Name + " " + recipe.Description + " " + recipe.AddetAt.ToString());
            _recipeRepository.add(recipe);
            MessageBox.Show("added!");

        }
    }
}
