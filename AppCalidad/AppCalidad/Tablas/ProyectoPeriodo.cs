using System;
using System.Collections.Generic;
using System.Text;

namespace AppCalidad.Tablas
{
    public class ProyectoPeriodo
    {
        public string CodProyecto { get; set; }
        public string CodPeriodo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Del { get; set; }
        public DateTime Al { get; set; }
        public string PeriodoCalendario { get; set; }
    }
}
