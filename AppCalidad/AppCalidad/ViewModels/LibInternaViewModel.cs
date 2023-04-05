using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppCalidad.Vistas;
using System.Collections.ObjectModel;
using SQLite;
using Plugin.Connectivity;
using System.Linq;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace AppCalidad.ViewModels
{
    public class LibInternaViewModel : BaseViewModel
    {
        private EProyectoElementoViewModel _ProyectoElementoVM;
        public INavigation Navigation { get; set; }
        public ICommand PopupCommand { get; set; }
        public ICommand ActualizarItemsCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private ObservableCollection<EProyectoElementoViewModel> _ObsProyectosElementos;
        public ObservableCollection<EProyectoElementoViewModel> ObsProyectosElementos
        {
            get { return _ObsProyectosElementos; }
            set { _ObsProyectosElementos = value; OnPropertyChanged(); }
        }
        List<Tablas.ProyectoElemento> ListProyectoelementos { get; set; }

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

        private double _cantLibNegroALib;
        public double CantLibNegroALib
        {
            get => _cantLibNegroALib;
            set
            {
                _cantLibNegroALib = value;
                OnPropertyChanged();
            }
        }

        public LibInternaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            PopupCommand = new Command(() => LlamarPopu());
            GetProyectoElementos();
            RefreshCommand = new Command(() =>
            {
                IsRefreshing = true;
                GetProyectoElementos();
                IsRefreshing = false;
            });
            ActualizarItemsCommand = new Command(() => ActualizarItems());
            SaveCommand = new Command((item) => {
                var i = CantLibNegroALib;

            });
        }

        void LlamarPopu()
        {
            var popupProperties = new ItemsElementos();
            PopupNavigation.PushAsync(popupProperties);
        }
        void ActualizarItems()
        {
            
        }
        public async void GetProyectoElementos()
        {
            try
            {
                using (var dialog = UserDialogs.Instance.Loading("Procesando..."))
                {
                    dialog.Show();
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Tablas.Proyectos>();
                        var db = new SQLiteConnection(App.FilePath);
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            IEnumerable<Tablas.ProyectoElemento> resultadoVal = GetAllProyectoElemento(db);
                            if (resultadoVal.Count() == 0)
                            {
                                //SincronizarProyectos();
                            }
                            //SincronizarProyectos();
                        }

                        ObsProyectosElementos = new ObservableCollection<EProyectoElementoViewModel>();
                        var ItemObsProyectos = GetAllProyectoElemento(db);
                        foreach (var item in ItemObsProyectos)
                        {
                            ObsProyectosElementos.Add(new EProyectoElementoViewModel(item));
                            await Task.Delay(1);
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
        public static IEnumerable<Tablas.ProyectoElemento> GetAllProyectoElemento(SQLiteConnection db)
        {
            string query = string.Format("SELECT * FROM ProyectoElemento Where CodProyecto = {0} And CodPeriodo = '{1}' ", App.CodProyectoGlobal, App.CodPeriodoGlobal);       
            return db.Query<Tablas.ProyectoElemento>(query);
        }
    }
}
