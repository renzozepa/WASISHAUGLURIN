namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActaLiberacionInternaDetalle")]
    public partial class ActaLiberacionInternaDetalle
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodProyecto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string NActaLiberacion { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string CodElemento { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CodMarca { get; set; }

        [StringLength(50)]
        public string Plano { get; set; }

        [StringLength(1)]
        public string Revision { get; set; }

        public int? Cantidad { get; set; }

        [StringLength(2)]
        public string VT { get; set; }

        [StringLength(2)]
        public string PT { get; set; }

        [StringLength(2)]
        public string UT { get; set; }

        [StringLength(2)]
        public string RT { get; set; }

        [StringLength(200)]
        public string Detalle { get; set; }

        [StringLength(200)]
        public string Observacion { get; set; }
    }
}
