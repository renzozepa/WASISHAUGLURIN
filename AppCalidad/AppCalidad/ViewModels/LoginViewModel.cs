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
    public class LoginViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { get; set; }
        public bool IsRemember { get; set; }

        bool _isEnabled = false;

        private ObservableCollection<Usuarios> _UsuariosTabla;
        public ObservableCollection<Usuarios> UsuariosTabla
        {
            get { return _UsuariosTabla; }
            set { _UsuariosTabla = value; OnPropertyChanged(); }
        }

        public List<Usuarios> ListUsuarios { get; set; }

        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; OnPropertyChanged(); }
        }
        private string _clave;
        public string Clave
        {
            get { return _clave; }
            set { _clave = value; OnPropertyChanged(); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        private ELoginViewModel _UsuarioVM;

        public ELoginViewModel UsuarioVM
        {
            get { return _UsuarioVM; }
            set { _UsuarioVM = value; OnPropertyChanged(); }
        }

        public LoginViewModel(INavigation navigation)
        {
            if (Settings.IsRemember)
            {
                Usuario = Settings.Usuario;
                Clave = Settings.Clave;
                IsRemember = Settings.IsRemember;
            }

            Navigation = navigation;
            LoginCommand = new Command(async () => await ValidarUsuario());
        }

        async Task ValidarUsuario()
        {
            try
            {
                IsEnabled = false;
                using (var dialog = UserDialogs.Instance.Loading("Procesando..."))
                {
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Usuarios>();
                        var db = new SQLiteConnection(App.FilePath);

                        if (CrossConnectivity.Current.IsConnected)
                        {
                            IEnumerable<Usuarios> resultadoVal = ValidarUsuarios(db);
                            if (resultadoVal.Count() == 0)
                               await SincronizarUsuario();
                        }

                        IEnumerable<Usuarios> resultado = ValidarLoginUsuario(db, Usuario, Clave);
                        if (resultado.Count() > 0)
                        {
                            Settings.IsRemember = this.IsRemember;
                            Settings.Usuario = this.Usuario;
                            Settings.Clave = this.Clave;

                            foreach (Usuarios itemUsuarios in resultado)
                            {
                                App.CodLoginGlobal = itemUsuarios.CodPersonal.ToString();
                            }
                            await Navigation.PushAsync(new Principal());
                        }
                    }       
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error : " + ex.Message.ToString(), "Aceptar");
            }
        }

        async Task SincronizarUsuario()
        {
            ListUsuarios = new List<Usuarios>();
            var t = Task.Run(async () => ListUsuarios = await HaugApi.Metodo.GetAllUsuario());

            t.Wait();

            int contador = 0;
            int cn = ListUsuarios.Count();

            using (var dialog = UserDialogs.Instance.Progress("Procesando..."))
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Usuarios>();
                    foreach (Usuarios itemUsuarios in ListUsuarios)
                    {
                        var DatosRegistro = new Usuarios
                        {
                            Usuario = itemUsuarios.Usuario.ToString().Trim(),
                            CodPersonal = itemUsuarios.CodPersonal,
                            password = itemUsuarios.password.ToString().Trim(),
                            RECORDAR = "false"
                        };

                        var db = new SQLiteConnection(App.FilePath);
                        IEnumerable<Usuarios> resultado = ValidarExitenciaUsuario(db, itemUsuarios.Usuario.ToString().Trim());
                        if (resultado.Count() > 0)
                        {
                            conn.Update(DatosRegistro);
                        }
                        else
                        {
                            conn.Insert(DatosRegistro);
                        }
                        await Task.Delay(10);
                        contador += contador;
                        dialog.PercentComplete = (contador / cn) * 100;
                    }
                }
            }
        }

        public static IEnumerable<Usuarios> ValidarExitenciaUsuario(SQLiteConnection db, string usuario)
        {
            return db.Query<Usuarios>("SELECT * FROM Usuarios where Usuario = ? ", usuario);
        }
        public static IEnumerable<Usuarios> ValidarLoginUsuario(SQLiteConnection db, string usuario , string clave)
        {
            return db.Query<Usuarios>("SELECT * FROM Usuarios where Usuario = ? And password = ? ", usuario , clave);
        }
        public static IEnumerable<Usuarios> ValidarUsuarios(SQLiteConnection db)
        {
            //db.Execute("Delete From Usuarios ");
            return db.Query<Usuarios>("SELECT * FROM Usuarios ");
        }
    }
}
