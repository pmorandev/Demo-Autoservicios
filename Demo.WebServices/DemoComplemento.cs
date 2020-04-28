namespace Demo.WebServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoComplemento")]
    public partial class DemoComplemento
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string ComplementoCodigo { get; set; }

        public decimal ComplementoPrecio { get; set; }

        [Required]
        [StringLength(1000)]
        public string ComplementoDescripcion { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ComplementoTipo { get; set; }

        public virtual DemoTipoCom DemoTipoCom { get; set; }
    }
}
