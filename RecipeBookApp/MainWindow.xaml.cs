using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using RecipeBookApp.Pages.ViewFunc;
using RecipeBookApp.ViewModel.Navigation;

namespace RecipeBookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigateWindowViewModel _windowViewModel = new NavigateWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
            Frame_MainPages.Navigate(new StartPage());
            _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
               (ToggleButtonViewAll, _windowViewModel.PageManager.ProductsSelecPage);

        }

        private void AllClick(object sender, RoutedEventArgs e)
        {
            _windowViewModel.PageManager.CurrentPage.Key.IsChecked = false;
            var btn = (ToggleButton)sender;

            switch (btn.Name.ToString())
            {
                case "ToggleButtonViewAll":
                    {
                        _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
                        (ToggleButtonViewAll, _windowViewModel.PageManager.ProductsSelecPage);
                    }
                    break;
                case "ToggleButtonAddFood":
                    {
                        _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
                        (ToggleButtonAddFood, _windowViewModel.PageManager.AddFoodPage);
                    }
                    break;
                case "ToggleButtonAddRecipe":
                    {
                        _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
                    (ToggleButtonAddRecipe, _windowViewModel.PageManager.AddRepicePage);
                    }
                    break;
            }
            Frame_MainPages.Navigate(_windowViewModel.PageManager.CurrentPage.Value);

        }
      
    }
}
