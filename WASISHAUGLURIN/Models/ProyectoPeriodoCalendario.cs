namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProyectoPeriodoCalendario")]
    public partial class ProyectoPeriodoCalendario
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string CodProyecto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CodPeriodo { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public DateTime? Del { get; set; }

        public DateTime? Al { get; set; }

        [StringLength(100)]
        public string PeriodoCalendario { get; set; }
    }
}
