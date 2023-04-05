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
    public class ProyectosViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand GoToDetailsCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        private ObservableCollection<EProyectosViewModel> _ObsProyectos;
        public ObservableCollection<EProyectosViewModel> ObsProyectos
        {
            get { return _ObsProyectos; }
            set { _ObsProyectos = value; OnPropertyChanged(); }
        }

        List<Tablas.Proyectos> ListProyectos { get; set; }

        private EProyectosViewModel _itemSeleccionado;
        public EProyectosViewModel ItemSeleccionado
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

        public ProyectosViewModel(INavigation navigation)
        {
            Navigation = navigation;

            RefreshCommand = new Command(() =>
            {
                IsRefreshing = true;
                GetProyectos();
                IsRefreshing = false;
            });
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));
        }

        public async void GetProyectos()
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
                            IEnumerable<Tablas.Proyectos> resultadoVal = GetAllProyectos(db);
                            if (resultadoVal.Count() == 0)
                            {
                                SincronizarProyectos();
                            }
                            //SincronizarProyectos();
                        }

                        ObsProyectos = new ObservableCollection<EProyectosViewModel>();
                        var ItemObsProyectos = GetAllProyectos(db);
                        foreach (var item in ItemObsProyectos)
                        {
                            ObsProyectos.Add(new EProyectosViewModel(item));
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
        void SincronizarProyectos()
        {
            ListProyectos = new List<Tablas.Proyectos>();
            var t = Task.Run(async () => ListProyectos = await HaugApi.Metodo.GetAllProyectos());
            t.Wait();
            //int contador = 0;
            int cn = ListProyectos.Count();

            //using (var dialog = UserDialogs.Instance.Progress("Procesando..."))
            //{
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Tablas.Proyectos>();
                    foreach (Tablas.Proyectos itemProyectos in ListProyectos)
                    {
                        var DatosRegistro = new Tablas.Proyectos
                        {
                            CodProyecto = itemProyectos.CodProyecto,
                            Descripcion = itemProyectos.Descripcion.ToString().Trim(),
                            Cliente = itemProyectos.Cliente.ToString().Trim(),
                            FecInicio = itemProyectos.FecInicio,
                            FecFin = itemProyectos.FecFin,
                            Anio = itemProyectos.Anio.ToString().Trim(),
                            Estado = itemProyectos.Estado.ToString().Trim(),
                            CodPartidaProyecto = itemProyectos.CodPartidaProyecto.ToString().Trim(),
                            Monto = itemProyectos.Monto,
                            PesoProyecto = itemProyectos.PesoProyecto,
                            TipoProyecto = itemProyectos.TipoProyecto,
                            LineaNegocio = itemProyectos.LineaNegocio.ToString().Trim(),
                            SemKGReal = itemProyectos.SemKGReal,
                            CodPeriodo = itemProyectos.CodPeriodo.ToString().Trim()
                        };

                        var db = new SQLiteConnection(App.FilePath);
                        IEnumerable<Tablas.Proyectos> resultado = ValidarExitenciaProyecto(db, itemProyectos.CodProyecto.ToString().Trim());
                        if (resultado.Count() > 0)
                        {
                            UpdateProyecto(conn, DatosRegistro);
                        }
                        else
                        {
                            conn.Insert(DatosRegistro);
                        }
                        //contador += contador;
                        //dialog.PercentComplete = (contador / cn) * 100;
                    }
                }
            //}
        }
        public static IEnumerable<Tablas.Proyectos> GetAllProyectos(SQLiteConnection db)
        {
            //db.Execute("Delete From Usuarios ");
            return db.Query<Tablas.Proyectos>("SELECT * FROM Proyectos ");
        }
        public static IEnumerable<Tablas.Proyectos> ValidarExitenciaProyecto(SQLiteConnection db, string codproyecto)
        {
            return db.Query<Tablas.Proyectos>("SELECT * FROM Proyectos where CodProyecto = ? ", codproyecto);
        }
        async Task GoToDetails(Type pageType)
        {
            if (ItemSeleccionado != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.BindingContext = new ProyectoViewModel(ItemSeleccionado, Navigation);
                await Navigation.PushAsync(page);

                ItemSeleccionado = null;
            }
        }
        public void VModelActive(Page sender, EventArgs eventArgs)
        {
            GetProyectos();
        }
        public void UpdateProyecto(SQLiteConnection cn, Tablas.Proyectos entidad)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(cn);
                cmd.CommandText = " Update Proyectos Set Descripcion = '" + entidad.Descripcion.ToString().Trim() + "' , Cliente = '" + entidad.Cliente.ToString().Trim() + "' , FecInicio = '" + entidad.FecInicio.ToString().Trim() + "' , FecFin = '" + entidad.FecFin.ToString().Trim() + "' , Anio = '" + entidad.Anio.ToString().Trim() +
                                  "' , Estado = '" + entidad.Estado.ToString().Trim() + "', CodPartidaProyecto = '" + entidad.CodPartidaProyecto.ToString().Trim() + "' , Monto = '" + entidad.Monto.ToString().Trim() + "' , PesoProyecto = '" + entidad.PesoProyecto.ToString().Trim() + "' , TipoProyecto = '" + entidad.TipoProyecto.ToString().Trim() +
                                  "' , LineaNegocio = '" + entidad.LineaNegocio.ToString().Trim() + "' , SemKGReal = '" + entidad.SemKGReal.ToString().Trim() + "' , CodPeriodo = '" + entidad.CodPeriodo.ToString().Trim() +
                                  "' WHERE CodProyecto = " + entidad.CodProyecto.ToString().Trim();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string error = ex.InnerException.ToString();
                throw;
            }

        }
    }
}
