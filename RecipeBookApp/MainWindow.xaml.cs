using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

        private void ToggleButtonViewAllClick(object sender, RoutedEventArgs e)
        {
            _windowViewModel.PageManager.CurrentPage.Key.IsChecked = false;
            _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
                (ToggleButtonViewAll, _windowViewModel.PageManager.ProductsSelecPage);
            Frame_MainPages.Navigate(_windowViewModel.PageManager.CurrentPage.Value);
        }


        private void ToggleButtonAddRecipeClick(object sender, RoutedEventArgs e)
        {
            _windowViewModel.PageManager.CurrentPage.Key.IsChecked = false;
            _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
                (ToggleButtonAddRecipe, _windowViewModel.PageManager.AddRepicePage);
            Frame_MainPages.Navigate(_windowViewModel.PageManager.CurrentPage.Value);
        }

        private void ToggleButtonAddFoodClick(object sender, RoutedEventArgs e)
        {
            _windowViewModel.PageManager.CurrentPage.Key.IsChecked = false;
            _windowViewModel.PageManager.CurrentPage = new KeyValuePair<System.Windows.Controls.Primitives.ToggleButton, Page>
                (ToggleButtonAddFood, _windowViewModel.PageManager.AddFoodPage);
            Frame_MainPages.Navigate(_windowViewModel.PageManager.CurrentPage.Value);
        }
    }
}
