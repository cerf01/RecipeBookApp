﻿using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.DAL.Moduls
{
    public class RecipeFood
    {
        public int FoodId{ get; set; }
        public Food Food {  get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
