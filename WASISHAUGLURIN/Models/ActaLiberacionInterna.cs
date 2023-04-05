namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActaLiberacionInterna")]
    public partial class ActaLiberacionInterna
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodProyecto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string NActaLiberacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int? CodRegistra { get; set; }

        public int? CodRecibe { get; set; }

        [StringLength(1)]
        public string Revision { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(9)]
        public string NActaLiberacion1 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string CodPeriodo { get; set; }
    }
}
