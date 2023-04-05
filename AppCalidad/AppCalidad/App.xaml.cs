using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using AppCalidad.Data;
using AppCalidad.Vistas;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCalidad
{
    public partial class App : Application
    {
        public static string CodPeriodoGlobal;
        public static string CodProyectoGlobal;
        public static string CodLoginGlobal;
        public static string FilePath = Path.Combine(
                        Environment.GetFolderPath(
                            System.Environment.SpecialFolder.Personal),
                        "AppCalidad.db3");

        private static DatabaseContext context;

        public static DatabaseContext Context
        {
            get
            {
                if (context == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(
                            System.Environment.SpecialFolder.Personal),
                        "AppCalidad.db3");
                    context = new DatabaseContext(dbPath);
                }

                return context;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
        }
        public App(string filepath)
        {
            FilePath = filepath;
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
