using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

using CityMap.ViewModels;

namespace CityMap.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CityDetailsPage : ContentPage
	{
		public CityDetailsPage(CityDetailsViewModel viewModel)
		{
			InitializeComponent();

            On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);

            BindingContext = viewModel;
		}
    }
}