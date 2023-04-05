using AppCalidad.Tablas;

namespace AppCalidad.ViewModels
{
    public class ELoginViewModel : BaseViewModel
    {
        private string _Usuario;
        public string Usuario { get { return _Usuario; } set { _Usuario = value; } }
        private int _CodPersonal;
        public int CodPersonal { get { return _CodPersonal; } set { _CodPersonal = value; } }
        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; } }


        public ELoginViewModel()
        {

        }

        public ELoginViewModel(Usuarios usu)
        {
            Usuario = usu.Usuario;
            CodPersonal = usu.CodPersonal;
            Password = usu.password;
        }

        public Usuarios GetUsuarios()
        {
            return new Usuarios()
            {
                Usuario = this.Usuario,
                CodPersonal = this.CodPersonal,
                password = this.Password
            };
        }

    }
}
