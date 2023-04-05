using System;
using System.Collections.Generic;
using System.Text;

namespace AppCalidad.Tablas
{
    public class Proyectos
    {
        public int CodProyecto { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
        public DateTime FecInicio { get; set; }
        public DateTime FecFin { get; set; }
        public string Anio { get; set; }
        public string Estado { get; set; }
        public string CodPartidaProyecto { get; set; }
        public decimal Monto { get; set; }
        public decimal PesoProyecto { get; set; }
        public string TipoProyecto { get; set; }
        public string LineaNegocio { get; set; }
        public int SemKGReal { get; set; }
        public string CodPeriodo { get; set; }
    }
}
