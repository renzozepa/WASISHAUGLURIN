using Acr.UserDialogs;
using AppCalidad.Tablas;
using AppCalidad.ServicioApi;
using AppCalidad.Vistas;
using AppCalidad.Helpers;
using Plugin.Connectivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace AppCalidad.ViewModels
{
    public class SincronizarViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand ProyElementoCommand { get; set; }

        public SincronizarViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
