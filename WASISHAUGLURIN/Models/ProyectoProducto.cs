namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProyectoProducto")]
    public partial class ProyectoProducto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodProyecto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string CodProducto { get; set; }

        [StringLength(500)]
        public string DescripcionProducto { get; set; }

        public int? CodTipoProducto { get; set; }

        public decimal? PesoTotalProducto { get; set; }

        public decimal? PesoAceroProducto { get; set; }

        [StringLength(50)]
        public string PlanoGeneral { get; set; }
    }
}
