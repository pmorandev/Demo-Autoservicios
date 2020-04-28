namespace Demo.Interfaz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoMenu")]
    public partial class DemoMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemoMenu()
        {
            DemoProduct = new HashSet<DemoProduct>();
        }

        [Key]
        [StringLength(100)]
        public string MenuCodigo { get; set; }

        [Required]
        [StringLength(1000)]
        public string MenuDescripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemoProduct> DemoProduct { get; set; }
    }
}
