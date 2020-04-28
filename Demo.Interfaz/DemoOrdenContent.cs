namespace Demo.Interfaz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoOrdenContent")]
    public partial class DemoOrdenContent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemoOrdenContent()
        {
            DemoOrdenContentComplemento = new HashSet<DemoOrdenContentComplemento>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrdenId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string OrdenProduct { get; set; }

        public int OrdenCantidad { get; set; }

        public decimal OrdenTotal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemoOrdenContentComplemento> DemoOrdenContentComplemento { get; set; }

        public virtual DemoOrdenHeader DemoOrdenHeader { get; set; }
    }
}
