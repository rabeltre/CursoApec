namespace PrimeraApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Detalle { get; set; }

        [Required]
        [StringLength(250)]
        public string Imagen { get; set; }

        public DateTime? Fecha { get; set; }

        public int? Likes { get; set; }

        public int? Views { get; set; }
    }
}
