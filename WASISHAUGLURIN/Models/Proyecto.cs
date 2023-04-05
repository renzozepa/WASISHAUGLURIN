namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proyecto")]
    public partial class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodProyecto { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(150)]
        public string Cliente { get; set; }

        public DateTime? FecInicio { get; set; }

        public DateTime? FecFin { get; set; }

        [StringLength(4)]
        public string Anio { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [StringLength(5)]
        public string CodPartidaProyecto { get; set; }

        public decimal? Monto { get; set; }

        public decimal? PesoProyecto { get; set; }

        [StringLength(50)]
        public string TipoProyecto { get; set; }

        [StringLength(50)]
        public string LineaNegocio { get; set; }

        public int? SemKGReal { get; set; }

        [StringLength(10)]
        public string CodPeriodo { get; set; }
    }
}
