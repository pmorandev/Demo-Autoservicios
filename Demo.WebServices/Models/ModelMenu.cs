using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebServices.Models
{
    public class ModelMenu
    {
        public string MenuCodigo { get; set; }
        public string MenuDescripcion { get; set; }
    }

    public class ModelProducto {
        public string ProductCodigo { get; set; }
        public string ProductDescripcion { get; set; }
        public int ProductCantidad { get; set; }
        public decimal ProductPrecio { get; set; }
        public decimal ProductTotal { get; set; }
        public string ProductTitulo { get; set; }
        public bool ProductComplementos { get; set; }
        public List<ModelComplemento> ProductComplementosElegidos { get; set; }
    }

    public class ModelTipoComplemento {
        public string TipoCodigo { get; set; }
        public string TipoDescripcion { get; set; }
        public int TipoMaxCantidad { get; set; }
        public int TipoCantidad { get; set; }
        public int TipoOrden { get; set; }
        public List<ModelComplemento> Complementos { get; set; }
    }

    public class ModelComplemento {
        public string ComplementoCodigo { get; set; }
        public decimal ComplementoPrecio { get; set; }
        public string ComplementoDescripcion { get; set; }
        public bool ComplementoSeleccionado { get; set; }
        public int ComplementoCantidad { get; set; }
    }

    public class ModelCanasta
    {
        public string Canal;
        public decimal Total;
        public int Cantidad;
        public string NumeroOrden;
        public List<ModelProducto> Items;
    }
}