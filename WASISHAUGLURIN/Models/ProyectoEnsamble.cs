namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProyectoEnsamble")]
    public partial class ProyectoEnsamble
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodProyecto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string CodProducto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string CodEnsamble { get; set; }

        [StringLength(500)]
        public string DescripcionEnsamble { get; set; }

        public decimal? PesoTotalEnsamble { get; set; }

        public decimal? PesoAceroEnsamble { get; set; }

        [StringLength(50)]
        public string PlanoEnsamble { get; set; }
    }
}
