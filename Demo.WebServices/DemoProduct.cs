namespace Demo.WebServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoProduct")]
    public partial class DemoProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemoProduct()
        {
            DemoTipoCom = new HashSet<DemoTipoCom>();
        }

        [Key]
        [StringLength(100)]
        public string ProductCodigo { get; set; }

        public int? ProductCantidad { get; set; }

        [Required]
        [StringLength(1000)]
        public string ProductDescripcion { get; set; }

        public decimal ProductPrecio { get; set; }

        public decimal? ProductTotal { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductTitulo { get; set; }

        public bool ProductComplementos { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductMenu { get; set; }

        public virtual DemoMenu DemoMenu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemoTipoCom> DemoTipoCom { get; set; }
    }
}
