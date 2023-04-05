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
    public class ProyectoViewModel : BaseViewModel
    {
        private EProyectosViewModel _ProyectoVM;
        List<Tablas.ProyectoPeriodo> ListProyectoPeriodos;
        List<Tablas.ProyectoElemento> ListProyectoElementos;
        public INavigation Navigation { get; set; }
        public ICommand LibInternaCommand { get; set; }
        public ICommand LibClienteCommand { get; set; }
        public ICommand DespachoCommand { get; set; }
        public ICommand SincroElementosCommand { get; set; }

        public ObservableCollection<EProyectoPeriodoViewModel> _lstProyPeriododisponible = new ObservableCollection<EProyectoPeriodoViewModel>();
        public ObservableCollection<EProyectoPeriodoViewModel> LstProyPeriododisponible
        {
            get { return _lstProyPeriododisponible; }
            set
            {
                if (_lstProyPeriododisponible != value)
                {
                    _lstProyPeriododisponible = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<EProyectoElementoViewModel> _lstEProyectoElementos = new ObservableCollection<EProyectoElementoViewModel>();
        public ObservableCollection<EProyectoElementoViewModel> LstProyElementos
        {
            get { return _lstEProyectoElementos; }
            set
            {
                if (_lstEProyectoElementos != value)
                {
                    _lstEProyectoElementos = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedIndexProyPeriodo;
        public string SelectedIndexProyPeriodo
        {
            get { return _selectedIndexProyPeriodo; }
            set
            {
                SetProperty(ref _selectedIndexProyPeriodo, value);
                SelectedDescripcionProyPeriodo = _lstProyPeriododisponible[Convert.ToInt32(_selectedIndexProyPeriodo)].CodPeriodo.ToString();
                App.CodPeriodoGlobal = SelectedDescripcionProyPeriodo;
                OnPropertyChanged();
            }
        }

        private string _selectedDescripcionProyPeriodo;
        public string SelectedDescripcionProyPeriodo
        {
            get { return _selectedDescripcionProyPeriodo; }
            set
            {
                SetProperty(ref _selectedDescripcionProyPeriodo, value);
                OnPropertyChanged();
            }
        }

        public EProyectosViewModel ProyectoVM
        {
            get { return _ProyectoVM; }
            set { _ProyectoVM = value; OnPropertyChanged(); }
        }

        public ProyectoViewModel(EProyectosViewModel Proy, INavigation navigation)
        {
            ProyectoVM = Proy;
            App.CodProyectoGlobal = Proy.CodProyecto.ToString();
            GetProyPeriodos(ProyectoVM.CodPartidaProyecto.ToString().Trim());
            Navigation = navigation;
            LibInternaCommand = new Command(() => VLibInterna());
            LibClienteCommand = new Command(() => VLibCliente());
            DespachoCommand = new Command(() => VDespacho());
            SincroElementosCommand = new Command(() => SincronizarElementos());
        }

        void GetProyPeriodos(string codproyecto)
        {
            try
            {
                using (var dialog = UserDialogs.Instance.Loading("Procesando..."))
                {
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Tablas.ProyectoPeriodo>();
                        var db = new SQLiteConnection(App.FilePath);

                        if (CrossConnectivity.Current.IsConnected)
                        {
                            IEnumerable<EProyectoPeriodoViewModel> resultadoVal = GetProyectoPeriodo(db, codproyecto);
                            if (resultadoVal.Count() == 0)
                                SincronizarProyectoPeriodoCalendario(codproyecto);
                        }

                        IEnumerable<EProyectoPeriodoViewModel> resultado = GetProyectoPeriodo(db, codproyecto);
                        if (resultado.Count() > 0)
                        {
                            LstProyPeriododisponible = new ObservableCollection<EProyectoPeriodoViewModel>(GetProyectoPeriodo(db, codproyecto));
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        void SincronizarProyectoPeriodoCalendario(string proyecto)
        {
            ListProyectoPeriodos = new List<Tablas.ProyectoPeriodo>();
            var t = Task.Run(async () => ListProyectoPeriodos = await HaugApi.Metodo.GetAllProyectoPeriodos(proyecto));

            t.Wait();

            int contador = 0;
            int cn = ListProyectoPeriodos.Count();

            using (var dialog = UserDialogs.Instance.Progress("Procesando..."))
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Tablas.ProyectoPeriodo>();
                    dialog.Show();
                    foreach (Tablas.ProyectoPeriodo itemProyectos in ListProyectoPeriodos)
                    {
                        var DatosRegistro = new Tablas.ProyectoPeriodo
                        {
                            CodProyecto = itemProyectos.CodProyecto,
                            CodPeriodo = itemProyectos.CodPeriodo.ToString().Trim(),
                            Descripcion = itemProyectos.Descripcion.ToString().Trim(),
                            Del = itemProyectos.Del,
                            Al = itemProyectos.Al,
                            PeriodoCalendario = itemProyectos.PeriodoCalendario.ToString()

                        };

                        var db = new SQLiteConnection(App.FilePath);
                        IEnumerable<EProyectoPeriodoViewModel> resultado = ValidarProyectoPeriodo(db, itemProyectos.CodProyecto.ToString().Trim(), itemProyectos.CodPeriodo.ToString().Trim());
                        if (resultado.Count() > 0)
                        {
                            UpdateProyectoPeriodo(conn, DatosRegistro);
                        }
                        else
                        {
                            conn.Insert(DatosRegistro);
                        }
                        Task.Delay(2);
                        contador += contador;
                        dialog.PercentComplete = (contador / cn) * 100;
                    }
                    dialog.Hide();
                }
            }
        }
        void SincronizarProyectoElemento(string proyecto)
        {
            ListProyectoElementos = new List<Tablas.ProyectoElemento>();

            var db = new SQLiteConnection(App.FilePath);
            DeleteAllProyectoElemento(db);

            var t = Task.Run(async () => ListProyectoElementos = await HaugApi.Metodo.GetAllProyectoElemento(proyecto));

            t.Wait();

            int contador = 0;
            int cn = ListProyectoElementos.Count();

            using (var dialog = UserDialogs.Instance.Progress("Procesando..."))
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Tablas.ProyectoElemento>();
                    dialog.Show();
                    foreach (Tablas.ProyectoElemento itemProyectoselementos in ListProyectoElementos)
                    {
                        var DatosRegistro = new Tablas.ProyectoElemento
                        {
                            CodProyecto = itemProyectoselementos.CodProyecto,
                            CodProducto = itemProyectoselementos.CodProducto,
                            CodEnsamble = itemProyectoselementos.CodEnsamble,
                            CodMarca = itemProyectoselementos.CodMarca,
                            CodElemento = itemProyectoselementos.CodElemento,
                            DescribeElemento = itemProyectoselementos.DescribeElemento,
                            Grado = itemProyectoselementos.Grado,
                            Cantidad = itemProyectoselementos.Cantidad,
                            Peso = itemProyectoselementos.Peso,
                            Area = itemProyectoselementos.Area,
                            Largo = itemProyectoselementos.Largo,
                            Plano = itemProyectoselementos.Plano,
                            Revision = itemProyectoselementos.Revision,
                            Nivel = itemProyectoselementos.Nivel,
                            Tipo = itemProyectoselementos.Tipo,
                            Pedido = itemProyectoselementos.Pedido,
                            Hoja = itemProyectoselementos.Hoja,
                            Fluido = itemProyectoselementos.Fluido,
                            PlgDiaTotal = itemProyectoselementos.PlgDiaTotal,
                            PlgDiaTaller = itemProyectoselementos.PlgDiaTaller,
                            PlgDiaObra = itemProyectoselementos.PlgDiaObra,
                            PlgDiaRanurada = itemProyectoselementos.PlgDiaRanurada,
                            PaintSystem = itemProyectoselementos.PaintSystem,
                            PlanoEnsamble = itemProyectoselementos.PlanoEnsamble,
                            Grupo = itemProyectoselementos.Grupo,
                            POE = itemProyectoselementos.POE,
                            CodContrata = itemProyectoselementos.CodContrata,
                            NOrdenTrabajo = itemProyectoselementos.NOrdenTrabajo,
                            NOrdenTrabajoGranalla = itemProyectoselementos.NOrdenTrabajoGranalla,
                            NOrdenTrabajoPintura = itemProyectoselementos.NOrdenTrabajoPintura,
                            AvanceFisico = itemProyectoselementos.AvanceFisico,
                            EstFinNegro = itemProyectoselementos.EstFinNegro,
                            FecFinNegro = itemProyectoselementos.FecFinNegro,
                            CantNegro = itemProyectoselementos.CantNegro,
                            EstLibNegro = itemProyectoselementos.EstLibNegro,
                            FecLibNegro = itemProyectoselementos.FecLibNegro,
                            CantLibNegro = itemProyectoselementos.CantLibNegro,
                            EstPinBase = itemProyectoselementos.EstPinBase,
                            FecPinBase = itemProyectoselementos.FecPinBase,
                            CantBase = itemProyectoselementos.CantBase,
                            EstPinAcabado = itemProyectoselementos.EstPinAcabado,
                            FecPinAcabado = itemProyectoselementos.FecPinAcabado,
                            CantAcabado = itemProyectoselementos.CantAcabado,
                            EstLibCliente = itemProyectoselementos.EstLibCliente,
                            FecLibCliente = itemProyectoselementos.FecLibCliente,
                            CantLibCliente = itemProyectoselementos.CantLibCliente,
                            NActaLibCliente = itemProyectoselementos.NActaLibCliente,
                            EstDespacho = itemProyectoselementos.EstDespacho,
                            NDespacho = itemProyectoselementos.NDespacho,
                            CantDespacho = itemProyectoselementos.CantDespacho,
                            FecDespacho = itemProyectoselementos.FecDespacho,
                            NPacking = itemProyectoselementos.NPacking,
                            ControlCambio = itemProyectoselementos.ControlCambio,
                            NotaTecnica = itemProyectoselementos.NotaTecnica,
                            NotaTecnicaPintura = itemProyectoselementos.NotaTecnicaPintura,
                            Ancho = itemProyectoselementos.Ancho,
                            Altura = itemProyectoselementos.Altura,
                            plgdiametral = itemProyectoselementos.plgdiametral,
                            Clasificacion = itemProyectoselementos.Clasificacion,
                            EstDocTrazabilidad = itemProyectoselementos.EstDocTrazabilidad,
                            FecDocTrazabilidad = itemProyectoselementos.FecDocTrazabilidad,
                            EstDocDimensional = itemProyectoselementos.EstDocDimensional,
                            FecDocDimensional = itemProyectoselementos.FecDocDimensional,
                            EstDocVisual = itemProyectoselementos.EstDocVisual,
                            FecDocVisual = itemProyectoselementos.FecDocVisual,
                            EstDocTintes = itemProyectoselementos.EstDocTintes,
                            FecDocTintes = itemProyectoselementos.FecDocTintes,
                            EstDocUltrasonido = itemProyectoselementos.EstDocUltrasonido,
                            FecDocUltrasonido = itemProyectoselementos.FecDocUltrasonido,
                            EstDocCapaBase = itemProyectoselementos.EstDocCapaBase,
                            FecDocCapaBase = itemProyectoselementos.FecDocCapaBase,
                            EstDocCapaAcabado = itemProyectoselementos.EstDocCapaAcabado,
                            FecDocCapaAcabado = itemProyectoselementos.FecDocCapaAcabado,
                            Carpeta = itemProyectoselementos.Carpeta,
                            EstLibPintura = itemProyectoselementos.EstLibPintura,
                            FecLibPintura = itemProyectoselementos.FecLibPintura,
                            CantLibPintura = itemProyectoselementos.CantLibPintura,
                            CodElementoAlterno1 = itemProyectoselementos.CodElementoAlterno1,
                            CodPeriodo = itemProyectoselementos.CodPeriodo,
                            AvanceMaterial = itemProyectoselementos.AvanceMaterial,
                            AvanceHabilitado = itemProyectoselementos.AvanceHabilitado,
                            AvanceRolPle = itemProyectoselementos.AvanceRolPle,
                            AvanceArmado = itemProyectoselementos.AvanceArmado,
                            AvanceSoldadura = itemProyectoselementos.AvanceSoldadura,
                            AvancePrensamble = itemProyectoselementos.AvancePrensamble,
                            AvanceInstLinSupp = itemProyectoselementos.AvanceInstLinSupp,
                            AvanceInspNegro = itemProyectoselementos.AvanceInspNegro,
                            AvanceGranallado = itemProyectoselementos.AvanceGranallado,
                            AvancePintura = itemProyectoselementos.AvancePintura,
                            AvanceInspFinal = itemProyectoselementos.AvanceInspFinal,
                            AvanceEmbalaje = itemProyectoselementos.AvanceEmbalaje

                        };

                        IEnumerable<EProyectoElementoViewModel> resultado = ValidarProyectoElemento(db, itemProyectoselementos.CodProyecto.ToString().Trim(), itemProyectoselementos.CodProducto.ToString().Trim(), itemProyectoselementos.CodEnsamble.ToString().Trim(), itemProyectoselementos.CodMarca.ToString().Trim(), itemProyectoselementos.CodElemento.ToString().Trim(), itemProyectoselementos.CodPeriodo.ToString().Trim());
                        if (resultado.Count() > 0)
                        {
                            UpdateProyectoElemento(conn,DatosRegistro);
                        }
                        else
                        {
                            conn.Insert(DatosRegistro);
                        }
                        Task.Delay(2);
                        contador += contador;
                        dialog.PercentComplete = (contador / cn) * 100;
                    }
                    dialog.Hide();
                }
            }
        }
        public static IEnumerable<EProyectoPeriodoViewModel> GetProyectoPeriodo(SQLiteConnection db, string codproyecto)
        {
            return db.Query<EProyectoPeriodoViewModel>("SELECT * FROM ProyectoPeriodo WHERE CodProyecto = ? ", codproyecto + "001");
        }
        public static IEnumerable<EProyectoPeriodoViewModel> ValidarProyectoPeriodo(SQLiteConnection db, string codproyecto, string codperiodo)
        {
            return db.Query<EProyectoPeriodoViewModel>("SELECT * FROM ProyectoPeriodo WHERE CodProyecto = ? And CodPeriodo = ? ", codproyecto, codperiodo);
        }
        public static IEnumerable<EProyectoElementoViewModel> ValidarProyectoElemento(SQLiteConnection db, string codproyecto, string producto, string ensamble, string marca, string elemento, string periodo)
        {
            try
            {
                string query = string.Format("SELECT * FROM ProyectoElemento WHERE CodProyecto = {0} And CodProducto = {1} And CodEnsamble = {2} And CodMarca = {3} And CodElemento = {4} And CodPeriodo = {5} ", codproyecto, producto, ensamble, marca, elemento, periodo);
                //string query = string.Format("SELECT * FROM ProyectoElemento WHERE CodPeriodo = '{0}' ", periodo);
                return db.Query<EProyectoElementoViewModel>(query);
            }
            catch (SQLiteException ex)
            {
                string error = ex.Message;
                throw;
            }

        }
        public void UpdateProyectoPeriodo(SQLiteConnection cn, Tablas.ProyectoPeriodo entidad)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(cn);
                cmd.CommandText = "Update ProyectoPeriodo Set Descripcion = " + entidad.Descripcion.ToString() + " , Del = " + entidad.Del + " , Al = " + entidad.Al + " , PeriodoCalendario = " + entidad.PeriodoCalendario + " WHERE CodProyecto = " + entidad.CodProyecto.ToString().Trim() + " And CodPeriodo = " + entidad.CodPeriodo.ToString().Trim();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string error = ex.InnerException.ToString();
                throw;
            }

        }
        public void UpdateProyectoElemento(SQLiteConnection cn, Tablas.ProyectoElemento entidad)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(cn);
                cmd.CommandText = " Update ProyectoElemento Set EstLibNegro = " + entidad.EstLibNegro.ToString() + " , FecLibNegro = " + entidad.FecLibNegro + " , CantLibNegro = " + entidad.CantLibNegro +
                                  " , AvanceMaterial = " + entidad.AvanceMaterial + " , AvanceHabilitado = " + entidad.AvanceHabilitado + " , AvanceRolPle = " + entidad.AvanceRolPle +
                                  " , AvanceArmado = " + entidad.AvanceArmado + " , AvanceSoldadura = " + entidad.AvanceSoldadura + " , AvancePrensamble = " + entidad.AvancePrensamble +
                                  " , AvanceInstLinSupp = " + entidad.AvanceInstLinSupp + " , AvanceInspNegro = " + entidad.AvanceInspNegro + " , AvanceGranallado = " + entidad.AvanceGranallado +
                                  " , AvancePintura = " + entidad.AvancePintura + " , AvanceInspFinal = " + entidad.AvanceInspFinal + " , AvanceEmbalaje = " + entidad.AvanceEmbalaje +
                                  " WHERE CodProyecto = " + entidad.CodProyecto.ToString().Trim() + " And CodPeriodo = " + entidad.CodPeriodo.ToString().Trim() +
                                  " And CodProducto = " + entidad.CodProducto.ToString().Trim() + " And CodEnsamble = " + entidad.CodEnsamble.ToString().Trim() +
                                  " And CodMarca = " + entidad.CodMarca.ToString().Trim() + " And CodElemento = " + entidad.CodElemento.ToString().Trim();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string error = ex.InnerException.ToString();
                throw;
            }

        }
        void VLibInterna()
        {
            try
            {
                Navigation.PushAsync(new LibInterna());
            }
            catch (Exception)
            {
                throw;
            }
        }
        void VLibCliente()
        {
            Navigation.PushAsync(new LibCliente());
        }
        void VDespacho()
        {
            Navigation.PushAsync(new Despacho());
        }
        void SincronizarElementos()
        {
            SincronizarProyectoElemento(App.CodProyectoGlobal);
        }

        public static IEnumerable<Tablas.ProyectoElemento> DeleteAllProyectoElemento(SQLiteConnection db)
        {
            db.Execute("Delete From ProyectoElemento ");
            //string query = string.Format("SELECT * FROM ProyectoElemento Where CodProyecto = {0} And CodPeriodo = '{1}' ", App.CodProyectoGlobal, App.CodPeriodoGlobal);
            string query = string.Format(" SELECT * FROM ProyectoElemento ");
            return db.Query<Tablas.ProyectoElemento>(query);
        }
    }
}
