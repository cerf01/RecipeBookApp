using RecipeBookApp.Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace RecipeBookApp.Pages.ViewFunc
{
    /// <summary>
    /// Interaction logic for AddRepicePage.xaml
    /// </summary>
    
    public partial class AddRepicePage : Page
    {
        private RecipeBookApp.Service.Service _service = new RecipeBookApp.Service.Service();
        public AddRepicePage()
        {
            InitializeComponent();
        } 

        private void AddRecipeButtonClick(object sender, RoutedEventArgs e)
        {
            var IngrItems = IngList.Items;
            var q = new List<string>();
            foreach (var item in IngrItems) 
            {
                q.Add(item.ToString());
            }

            _service.AddNewRecipe(q, DishNameInput.Text, DescriptionInput.Text);

        }

        private void AddToListButtonClick(object sender, RoutedEventArgs e)
        {
            var str = FoodFromDb.Text;
            var foodList = _service.GetFoodList();

            if (!foodList.Any(f => f.Name == str))
                return;
            IngList.Items.Add(str);


        }

        private void ClearBox(object sender, RoutedEventArgs e)
        {
            var txtBox = (TextBox)sender;
            txtBox.Text = "";

        }
    }
}
