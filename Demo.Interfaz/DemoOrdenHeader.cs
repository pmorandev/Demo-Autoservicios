namespace Demo.Interfaz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoOrdenHeader")]
    public partial class DemoOrdenHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemoOrdenHeader()
        {
            DemoOrdenContent = new HashSet<DemoOrdenContent>();
        }

        [Key]
        public int Orden { get; set; }

        [Required]
        [StringLength(100)]
        public string OrdenCanal { get; set; }

        public decimal OrdenTotal { get; set; }

        public int OrdenCantidad { get; set; }

        public int OrdenEstado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemoOrdenContent> DemoOrdenContent { get; set; }
    }
}
