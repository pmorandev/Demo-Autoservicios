namespace Demo.Interfaz
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoBD : DbContext
    {
        public DemoBD()
            : base("name=DemoBD")
        {
        }

        public virtual DbSet<DemoComplemento> DemoComplemento { get; set; }
        public virtual DbSet<DemoMenu> DemoMenu { get; set; }
        public virtual DbSet<DemoProduct> DemoProduct { get; set; }
        public virtual DbSet<DemoTipoCom> DemoTipoCom { get; set; }
        public virtual DbSet<DemoOrdenContent> DemoOrdenContent { get; set; }
        public virtual DbSet<DemoOrdenContentComplemento> DemoOrdenContentComplemento { get; set; }
        public virtual DbSet<DemoOrdenHeader> DemoOrdenHeader { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DemoComplemento>()
                .Property(e => e.ComplementoPrecio)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoMenu>()
                .HasMany(e => e.DemoProduct)
                .WithRequired(e => e.DemoMenu)
                .HasForeignKey(e => e.ProductMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DemoProduct>()
                .Property(e => e.ProductPrecio)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoProduct>()
                .Property(e => e.ProductTotal)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoProduct>()
                .HasMany(e => e.DemoTipoCom)
                .WithRequired(e => e.DemoProduct)
                .HasForeignKey(e => e.TipoProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DemoTipoCom>()
                .HasMany(e => e.DemoComplemento)
                .WithRequired(e => e.DemoTipoCom)
                .HasForeignKey(e => e.ComplementoTipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DemoOrdenContent>()
                .Property(e => e.OrdenTotal)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoOrdenContent>()
                .HasMany(e => e.DemoOrdenContentComplemento)
                .WithRequired(e => e.DemoOrdenContent)
                .HasForeignKey(e => new { e.OrdenId, e.OrdenProduct })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DemoOrdenContentComplemento>()
                .Property(e => e.OrdenComplementoPrecio)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoOrdenContentComplemento>()
                .Property(e => e.OrdenComplementoTotal)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoOrdenHeader>()
                .Property(e => e.OrdenTotal)
                .HasPrecision(19, 2);

            modelBuilder.Entity<DemoOrdenHeader>()
                .HasMany(e => e.DemoOrdenContent)
                .WithRequired(e => e.DemoOrdenHeader)
                .HasForeignKey(e => e.OrdenId)
                .WillCascadeOnDelete(false);
        }
    }
}
