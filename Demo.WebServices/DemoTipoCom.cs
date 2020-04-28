namespace Demo.WebServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoTipoCom")]
    public partial class DemoTipoCom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemoTipoCom()
        {
            DemoComplemento = new HashSet<DemoComplemento>();
        }

        [Key]
        [StringLength(100)]
        public string TipoCodigo { get; set; }

        [Required]
        [StringLength(1000)]
        public string TipoDescripcion { get; set; }

        public int TipoMaxCantidad { get; set; }

        public int? TipoCantidad { get; set; }

        public int TipoOrden { get; set; }

        [Required]
        [StringLength(100)]
        public string TipoProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemoComplemento> DemoComplemento { get; set; }

        public virtual DemoProduct DemoProduct { get; set; }
    }
}
