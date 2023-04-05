using AppCalidad.Tablas;
using System;

namespace AppCalidad.ViewModels
{
    public class EProyectoPeriodoViewModel : BaseViewModel
    {
        private string _CodProyecto;
        public string CodProyecto { get { return _CodProyecto; } set { _CodProyecto = value; } }
        private string _CodPeriodo;
        public string CodPeriodo { get { return _CodPeriodo; } set { _CodPeriodo = value; } }
        private string _Descripcion;
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        private DateTime _Del;
        public DateTime Del { get { return _Del; } set { _Del = value; } }
        private DateTime _Al;
        public DateTime Al { get { return _Al; } set { _Al = value; } }
        private string _PeriodoCalendario;
        public string PeriodoCalendario { get { return _PeriodoCalendario; } set { _PeriodoCalendario = value; } }

        public EProyectoPeriodoViewModel()
        {

        }

        public EProyectoPeriodoViewModel(Tablas.ProyectoPeriodo ProyPeriodo)
        {
            CodProyecto = ProyPeriodo.CodProyecto;
            CodPeriodo = ProyPeriodo.CodPeriodo;
            Descripcion = ProyPeriodo.Descripcion;
            Del = ProyPeriodo.Del;
            Al = ProyPeriodo.Al;
            PeriodoCalendario = ProyPeriodo.PeriodoCalendario;
        }
        public Tablas.ProyectoPeriodo GetProyectoPeriodo()
        {
            return new Tablas.ProyectoPeriodo()
            {
                CodProyecto = this.CodProyecto,
                CodPeriodo = this.CodPeriodo,
                Descripcion = this.Descripcion,
                Del = this.Del,
                Al = this.Al,
                PeriodoCalendario = this.PeriodoCalendario
            };
        }
    }
}
