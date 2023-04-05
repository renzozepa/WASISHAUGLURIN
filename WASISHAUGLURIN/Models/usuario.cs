namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [StringLength(20)] 
        [Key]
        public string Usuario { get; set; } 

        public int? CodPersonal { get; set; }

        [StringLength(50)]
        public string password { get; set; }
    }
}
