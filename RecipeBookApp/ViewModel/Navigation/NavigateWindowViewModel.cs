namespace RecipeBookApp.ViewModel.Navigation
{

    public class NavigateWindowViewModel
    {
        public PageNavigationManager PageManager { get; set; }
        public NavigateWindowViewModel()
        {
            PageManager = new PageNavigationManager();
        }
    }

}
