namespace PrimeraApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblLike
    {
        public int Id { get; set; }

        public DateTime fecha { get; set; }

        public int PostID { get; set; }

        public int? Operacion { get; set; }
    }
}
