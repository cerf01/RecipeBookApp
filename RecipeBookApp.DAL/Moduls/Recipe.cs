using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.DAL.Moduls
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<RecipeFood> RecipeFood { get; set; }

        public DateTime AddetAt { get; set; }
        
    }
}
