using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Acr.UserDialogs;
using Syncfusion.Licensing;

namespace AppCalidad.Droid
{
    [Activity(Label = "CalidadHaug", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            SyncfusionLicenseProvider.RegisterLicense("NTIzMTIxQDMxMzkyZTMzMmUzMG9rMVRVajA0YTFudmFUeUZISnFwQlRtOWZ3ZDAvREEwYm5yUkJaMGZxV1E9");

            global::Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            Rg.Plugins.Popup.Popup.Init(this);            
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}