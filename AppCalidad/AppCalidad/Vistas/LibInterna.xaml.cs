using AppCalidad.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalidad.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LibInterna : ContentPage
	{
		public LibInterna ()
		{
			InitializeComponent ();
            BindingContext = new LibInternaViewModel(this.Navigation);
        }
    }
}