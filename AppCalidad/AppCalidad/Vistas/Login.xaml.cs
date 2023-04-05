using AppCalidad.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalidad.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            BindingContext = new LoginViewModel(this.Navigation);
        }
	}
}