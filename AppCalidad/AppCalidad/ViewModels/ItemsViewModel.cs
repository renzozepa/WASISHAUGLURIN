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
    public class ItemsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand GoToDetailsCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        private ObservableCollection<EProyectoElementoViewModel> _ObsProyectoElemento;
        public ObservableCollection<EProyectoElementoViewModel> ObsProyectoElemento
        {
            get { return _ObsProyectoElemento; }
            set { _ObsProyectoElemento = value; OnPropertyChanged(); }
        }
        private EProyectoElementoViewModel _itemSeleccionado;
        public EProyectoElementoViewModel ItemSeleccionado
        {
            get { return _itemSeleccionado; }
            set { _itemSeleccionado = value; OnPropertyChanged(); }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetProyectoElementos();
            RefreshCommand = new Command(() =>
            {
                IsRefreshing = true;
                GetProyectoElementos();
                IsRefreshing = false;
            });
            GoToDetailsCommand = new Command(() => ItemSeleccionadoClick());
        }
        async void GetProyectoElementos()
        {
            try
            {
                using (var dialog = UserDialogs.Instance.Loading("Procesando..."))
                {
                    dialog.Show();
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        
                        var db = new SQLiteConnection(App.FilePath);
                        ObsProyectoElemento = new ObservableCollection<EProyectoElementoViewModel>();
                        var ItemObsProyectos = GetAllProyectoelemento(db,App.CodProyectoGlobal);
                        foreach (var item in ItemObsProyectos)
                        {
                            ObsProyectoElemento.Add(new EProyectoElementoViewModel(item));
                        }
                    }
                    dialog.Hide();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error : " + ex.Message.ToString(), "Aceptar");
            }
        }
        void ItemSeleccionadoClick()
        {
            if (ItemSeleccionado != null)
            {
                ItemSeleccionado = null;
            }
        }
        public static IEnumerable<Tablas.ProyectoElemento> GetAllProyectoelemento(SQLiteConnection db , string proyecto)
        {
            db.CreateTable<Tablas.ProyectoElemento>();
            return db.Query<Tablas.ProyectoElemento>("SELECT * FROM ProyectoElemento WHERE CodProyecto = " + proyecto);
        }
    }
}
