using Android.App;
using Android.OS;

namespace CakeList.Droid
{
    [Activity(Label = "Waracle - Candidate App", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            new Handler().PostDelayed(() => { StartActivity(typeof(MainActivity)); }, 2000);
        }
    }
}
