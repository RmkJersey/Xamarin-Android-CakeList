using CakeList.Interfaces;
using CakeList.Services;
using CakeList.Views;
using CommonServiceLocator;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace CakeList
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            UnityContainer u = new UnityContainer();
            u.RegisterType<INetworkHelper, NetworkHelper>();
            u.RegisterType<IDownloadCakeList, DownloadCakeList>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(u));

            MainPage = new NavigationPage(new MainPageView());
        }
    }
}
