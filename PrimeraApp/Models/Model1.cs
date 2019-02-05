namespace PrimeraApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Oracione> Oraciones { get; set; }
        public virtual DbSet<tblLike> tblLikes { get; set; }
        public virtual DbSet<tblPost> tblPosts { get; set; }
        public virtual DbSet<tblVoto> tblVotos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsFixedLength();

            modelBuilder.Entity<tblPost>()
                .Property(e => e.Detalle)
                .IsUnicode(false);

            modelBuilder.Entity<tblPost>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<tblVoto>()
                .Property(e => e.NombrePartido)
                .IsUnicode(false);
        }
    }
}
