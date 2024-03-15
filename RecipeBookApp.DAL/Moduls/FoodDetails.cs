using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.DAL.Moduls
{
    public class FoodDetails
    {
        public int Id { get; set; }
        public float Calories { get; set; }

        public float FatTota { get; set; }
      
        public float Protein { get; set; }

        public float Fiber { get; set; }

        public float Sugar{ get; set; }
    }
}
