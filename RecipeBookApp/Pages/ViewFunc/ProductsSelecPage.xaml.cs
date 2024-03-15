using RecipeBookApp.DataView;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RecipeBookApp.Pages.ViewFunc
{
    /// <summary>
    /// Interaction logic for ProductsSelecPage.xaml
    /// </summary>
    /// 
    public partial class ProductsSelecPage : Page
    {
   
        private FoodForViewController  _foodViewCntrl = new FoodForViewController();
        private ToggleButton? _lastInput = new ToggleButton();
        private RecipeBookApp.Service.Service _service = new RecipeBookApp.Service.Service();
        public ProductsSelecPage()
        {
            InitializeComponent();
            UpdateData();
            DataGrid.ItemsSource = _foodViewCntrl.FoodForViews;
            _lastInput = ToggleButtonAll;
        }

        private void UpdateData() 
        {
            var foodList = _service.GetFoodList();
            _foodViewCntrl.setFoodForViewController(foodList);
        }
      
        private void SetData(string switcher)
        {
            UpdateData();
            switch (switcher)
            {
                case "ToggleButtonAll":
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews;
                    break;
                case "ToggleButtonVegetable":
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews.Where(f => f.Type == FoodType.Vegetable);
                    break;
                case "ToggleButtonFruit":
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews.Where(f => f.Type == FoodType.Fruit);
                    break;
                case "ToggleButtonGroats":
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews.Where(f => f.Type == FoodType.Groat);
                    break;
                case "ToggleButtonSpuices":
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews.Where(f => f.Type == FoodType.Spice);
                    break;
                case "ToggleButtonBaking":
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews.Where(f => f.Type == FoodType.Baking);
                    break;
                case "ToggleButtonDishes":
                    DataGrid.ItemsSource = _service.GetRecipesList();
                    break;
                default:
                    DataGrid.ItemsSource = _foodViewCntrl.FoodForViews;
                    break;

            }
        }
        private void ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            _lastInput.IsChecked = false;
            var btn = (ToggleButton)sender;
            _lastInput = btn;
            SetData(btn.Name.ToString());

        }
     
    }
}
