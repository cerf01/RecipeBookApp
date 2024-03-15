using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using RecipeBookApp.Pages.ViewFunc;

namespace RecipeBookApp.ViewModel.Navigation
{
    public class PageNavigationManager
    {

        public ProductsSelecPage ProductsSelecPage = new ProductsSelecPage();
        public AddFood AddFoodPage = new AddFood();
        public AddRepicePage AddRepicePage = new AddRepicePage();

        public KeyValuePair<ToggleButton, Page> CurrentPage;
    }

}
