using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCalidad.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalidad.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Proyectos : ContentPage
	{
        ProyectosViewModel vm;
        public Proyectos ()
		{
			InitializeComponent ();
            vm = new ProyectosViewModel(this.Navigation);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.VModelActive(this, EventArgs.Empty);
        }
    }
}