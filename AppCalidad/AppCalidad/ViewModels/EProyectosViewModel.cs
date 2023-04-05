using AppCalidad.Tablas;
using System;

namespace AppCalidad.ViewModels
{
    public class EProyectosViewModel : BaseViewModel
    {
        private int _CodProyecto;
        public int CodProyecto { get { return _CodProyecto; } set { _CodProyecto = value; } }
        private string _Descripcion;
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        private string _Cliente;
        public string Cliente { get { return _Cliente; } set { _Cliente = value; } }
        private DateTime _FecInicio;
        public DateTime FecInicio { get { return _FecInicio; } set { _FecInicio = value; } }
        private DateTime _FecFin;
        public DateTime FecFin { get { return _FecFin; } set { _FecFin = value; } }
        private string _Anio;
        public string Anio { get { return _Anio; } set { _Anio = value; } }
        private string _Estado;
        public string Estado { get { return _Estado; } set { _Estado = value; } }
        private string _CodPartidaProyecto;
        public string CodPartidaProyecto { get { return _CodPartidaProyecto; } set { _CodPartidaProyecto = value; } }
        private decimal _Monto;
        public decimal Monto { get { return _Monto; } set { _Monto = value; } }
        private decimal _PesoProyecto;
        public decimal PesoProyecto { get { return _PesoProyecto; } set { _PesoProyecto = value; } }
        private string _TipoProyecto;
        public string TipoProyecto { get { return _TipoProyecto; } set { _TipoProyecto = value; } }
        private string _LineaNegocio;
        public string LineaNegocio { get { return _LineaNegocio; } set { _LineaNegocio = value; } }
        private int _SemKGReal;
        public int SemKGReal { get { return _SemKGReal; } set { _SemKGReal = value; } }
        private string _CodPeriodo;
        public string CodPeriodo { get { return _CodPeriodo; } set { _CodPeriodo = value; } }

        public EProyectosViewModel()
        {
        
        }

        public EProyectosViewModel(Proyectos proy)
        {
            CodProyecto = proy.CodProyecto;
            Descripcion = proy.Descripcion;
            Cliente = proy.Cliente;
            FecInicio = proy.FecInicio;
            FecFin = proy.FecFin;
            Anio = proy.Anio;
            Estado = proy.Estado;
            CodPartidaProyecto = proy.CodPartidaProyecto;
            Monto = proy.Monto;
            PesoProyecto = proy.PesoProyecto;
            TipoProyecto = proy.TipoProyecto;
            LineaNegocio = proy.LineaNegocio;
            SemKGReal = proy.SemKGReal;
            CodPeriodo = proy.CodPeriodo;
        }

        public Proyectos GetProyectosAll()
        {
            return new Proyectos()
            {
                CodProyecto = this.CodProyecto,
                Descripcion = this.Descripcion,
                Cliente = this.Cliente,
                FecInicio = this.FecInicio,
                FecFin = this.FecFin,
                Anio = this.Anio,
                Estado = this.Estado,
                CodPartidaProyecto = this.CodPartidaProyecto,
                Monto = this.Monto,
                PesoProyecto = this.PesoProyecto,
                TipoProyecto = this.TipoProyecto,
                LineaNegocio = this.LineaNegocio,
                SemKGReal = this.SemKGReal,
                CodPeriodo = this.CodPeriodo
        };
        }
    }
}
