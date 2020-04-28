namespace Demo.WebServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoOrdenContentComplemento")]
    public partial class DemoOrdenContentComplemento
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrdenId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string OrdenProduct { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string OrdenTipo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string OrdenComplemento { get; set; }

        public int OrdenComplementoCantidad { get; set; }

        public decimal OrdenComplementoPrecio { get; set; }

        public decimal OrdenComplementoTotal { get; set; }

        public virtual DemoOrdenContent DemoOrdenContent { get; set; }
    }
}
