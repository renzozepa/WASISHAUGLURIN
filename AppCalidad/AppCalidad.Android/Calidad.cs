using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppCalidad.Droid
{
    [Activity(Label = "Calidad Haug", Theme = "@style/SplashThemeX", MainLauncher = true, NoHistory = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize)]
    public class Calidad : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            // Create your application here
        }
    }
}