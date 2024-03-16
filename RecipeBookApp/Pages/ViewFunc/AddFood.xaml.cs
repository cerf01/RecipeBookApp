using GetFoodFromApi;
using System.Linq;
using System.Windows;
using System.Windows.Controls;



namespace RecipeBookApp.Pages.ViewFunc
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Page
    {
        private RecipeBookApp.Service.Service _service = new RecipeBookApp.Service.Service();
        public AddFood()
        {
            InitializeComponent();
            
        }

        private void AddCkick(object sender, RoutedEventArgs e)
        {
            var query = Input.Text.ToLower();

            var FoodList = new FfAController(query);

            if (FoodList.FoodFromApi.Count() <= 0)
                return;
           var type = GetInputedType(TypesList.SelectionBoxItem.ToString());
            if(type==null) 
                return;
            _service.AddNewFood(FoodList.FoodFromApi, (FoodType)type);
            MessageBox.Show("added!");

        }

        private FoodType? GetInputedType(string input) 
        {
            switch (input) 
            {
                case "Fruit": return FoodType.Fruit;
                case "Vegetable": return FoodType.Vegetable;
                case "Groat": return FoodType.Groat;
                case "Spice": return FoodType.Spice;
                case "Baking": return FoodType.Baking;
                default: return null;
            }
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            Input.Text = "";
        }

    }
}
