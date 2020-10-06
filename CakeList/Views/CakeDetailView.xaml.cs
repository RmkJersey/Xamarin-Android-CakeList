using CakeList.Models;
using Xamarin.Forms.Xaml;

namespace CakeList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CakeDetailView
    {
        public CakeDetailView(WaracleCake cake)
        {
            InitializeComponent();

            CakeDescription.Text = cake.Desc;
            CakeImage.Source = cake.Image;
        }
    }
}