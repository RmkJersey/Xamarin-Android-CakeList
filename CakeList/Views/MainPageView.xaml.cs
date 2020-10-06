using CakeList.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using CakeList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CakeList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageView
    {
        public MainPageView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);

            TriggerLogoAnimation();
        }

        private async void TriggerLogoAnimation()
        {
            WaracleLogo.Opacity = 0;
            WaracleLogo.TranslationY = -120;

            await Task.Delay(500);

            await Task.WhenAll(
                WaracleLogo.FadeTo(1, 600, Easing.Linear),
                WaracleLogo.TranslateTo(0, 0, 600, Easing.BounceOut));
        }

        private async void CakeViewList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is WaracleCake waracleCake))
                return;

            await PopupNavigation.Instance.PushAsync(new CakeDetailView(waracleCake));

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void RefreshButton_OnClicked(object sender, EventArgs e)
        {
            RefreshButton.IsEnabled = false;
            await Task.Delay(1000);
            RefreshButton.IsEnabled = true;
        }
    }
}