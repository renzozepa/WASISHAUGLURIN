using Acr.UserDialogs;
using AppCalidad.ViewModels;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalidad.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsElementos 
	{
        public ICommand RefreshCommand { get; set; }

        private ObservableCollection<EProyectoElementoViewModel> _ObsProyectosElementosI;
        public ObservableCollection<EProyectoElementoViewModel> ObsProyectosElementosI
        {
            get { return _ObsProyectosElementosI; }
            set { _ObsProyectosElementosI = value; OnPropertyChanged(); }
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
        public ItemsElementos ()
		{
			InitializeComponent ();
            GetProyectoElementos();
            RefreshCommand = new Command(() =>
            {
                IsRefreshing = true;
                GetProyectoElementos();
                IsRefreshing = false;
            });
        }

        private void BtnLibInterna_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
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
                        conn.CreateTable<Tablas.ProyectoElemento>();
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

                        ObsProyectosElementosI = new ObservableCollection<EProyectoElementoViewModel>();
                        var ItemObsProyectos = GetAllProyectoElemento(db);
                        foreach (var item in ItemObsProyectos)
                        {
                            ObsProyectosElementosI.Add(new EProyectoElementoViewModel(item));
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