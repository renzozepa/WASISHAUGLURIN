namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProyectoElemento")]
    public partial class ProyectoElemento
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

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CodMarca { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string CodElemento { get; set; }

        [StringLength(80)]
        public string DescribeElemento { get; set; }

        [StringLength(20)]
        public string Grado { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Peso { get; set; }

        public decimal? Area { get; set; }

        public decimal? Largo { get; set; }

        [StringLength(50)]
        public string Plano { get; set; }

        [StringLength(1)]
        public string Revision { get; set; }

        public int? Nivel { get; set; }

        [StringLength(3)]
        public string Tipo { get; set; }

        [StringLength(10)]
        public string Pedido { get; set; }

        [StringLength(15)]
        public string Hoja { get; set; }

        [StringLength(10)]
        public string Fluido { get; set; }

        public decimal? PlgDiaTotal { get; set; }

        public decimal? PlgDiaTaller { get; set; }

        public decimal? PlgDiaObra { get; set; }

        public decimal? PlgDiaRanurada { get; set; }

        [StringLength(30)]
        public string PaintSystem { get; set; }

        [StringLength(30)]
        public string PlanoEnsamble { get; set; }

        [StringLength(50)]
        public string Grupo { get; set; }

        [StringLength(10)]
        public string POE { get; set; }

        public int? CodContrata { get; set; }

        [StringLength(30)]
        public string NOrdenTrabajo { get; set; }

        [StringLength(30)]
        public string NOrdenTrabajoGranalla { get; set; }

        [StringLength(30)]
        public string NOrdenTrabajoPintura { get; set; }

        public int? AvanceFisico { get; set; }

        [StringLength(1)]
        public string EstFinNegro { get; set; }

        public DateTime? FecFinNegro { get; set; }

        public int? CantNegro { get; set; }

        [StringLength(1)]
        public string EstLibNegro { get; set; }

        public DateTime? FecLibNegro { get; set; }

        public int? CantLibNegro { get; set; }

        [StringLength(1)]
        public string EstPinBase { get; set; }

        public DateTime? FecPinBase { get; set; }

        public int? CantBase { get; set; }

        [StringLength(1)]
        public string EstPinAcabado { get; set; }

        public DateTime? FecPinAcabado { get; set; }

        public int? CantAcabado { get; set; }

        [StringLength(1)]
        public string EstLibCliente { get; set; }

        public DateTime? FecLibCliente { get; set; }

        public int? CantLibCliente { get; set; }

        [StringLength(20)]
        public string NActaLibCliente { get; set; }

        [StringLength(1)]
        public string EstDespacho { get; set; }

        [StringLength(20)]
        public string NDespacho { get; set; }

        public int? CantDespacho { get; set; }

        public DateTime? FecDespacho { get; set; }

        [StringLength(20)]
        public string NPacking { get; set; }

        [StringLength(500)]
        public string ControlCambio { get; set; }

        [StringLength(500)]
        public string NotaTecnica { get; set; }

        [StringLength(500)]
        public string NotaTecnicaPintura { get; set; }

        public decimal? Ancho { get; set; }

        public decimal? Altura { get; set; }

        public decimal? plgdiametral { get; set; }

        [StringLength(30)]
        public string Clasificacion { get; set; }

        [StringLength(1)]
        public string EstDocTrazabilidad { get; set; }

        public DateTime? FecDocTrazabilidad { get; set; }

        [StringLength(1)]
        public string EstDocDimensional { get; set; }

        public DateTime? FecDocDimensional { get; set; }

        [StringLength(1)]
        public string EstDocVisual { get; set; }

        public DateTime? FecDocVisual { get; set; }

        [StringLength(1)]
        public string EstDocTintes { get; set; }

        public DateTime? FecDocTintes { get; set; }

        [StringLength(1)]
        public string EstDocUltrasonido { get; set; }

        public DateTime? FecDocUltrasonido { get; set; }

        [StringLength(1)]
        public string EstDocCapaBase { get; set; }

        public DateTime? FecDocCapaBase { get; set; }

        [StringLength(1)]
        public string EstDocCapaAcabado { get; set; }

        public DateTime? FecDocCapaAcabado { get; set; }

        [StringLength(50)]
        public string Carpeta { get; set; }

        [StringLength(1)]
        public string EstLibPintura { get; set; }

        public DateTime? FecLibPintura { get; set; }

        public int? CantLibPintura { get; set; }

        [StringLength(50)]
        public string CodElementoAlterno1 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string CodPeriodo { get; set; }

        public decimal? AvanceMaterial { get; set; }

        public decimal? AvanceHabilitado { get; set; }

        public decimal? AvanceRolPle { get; set; }

        public decimal? AvanceArmado { get; set; }

        public decimal? AvanceSoldadura { get; set; }

        public decimal? AvancePrensamble { get; set; }

        public decimal? AvanceInstLinSupp { get; set; }

        public decimal? AvanceInspNegro { get; set; }

        public decimal? AvanceGranallado { get; set; }

        public decimal? AvancePintura { get; set; }

        public decimal? AvanceInspFinal { get; set; }

        public decimal? AvanceEmbalaje { get; set; }
    }
}
