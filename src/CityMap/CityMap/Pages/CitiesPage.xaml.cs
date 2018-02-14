using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CityMap.ViewModels;

namespace CityMap.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitiesPage : ContentPage
    {
        public CitiesPage(CitiesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = (CitiesViewModel)BindingContext;

            if (viewModel.LoadDataCommand.CanExecute(null))
            {
                viewModel.LoadDataCommand.Execute(null);
            }
        }
    }
}