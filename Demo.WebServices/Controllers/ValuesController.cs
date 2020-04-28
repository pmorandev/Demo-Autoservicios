using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebServices.Controllers
{
    public class ValuesController : ApiController
    {
        public List<Models.ModelMenu> GetMenus() {
            List<Models.ModelMenu> oRes = new List<Models.ModelMenu>();
            try
            {
                DemoBD oBaseDemo = new DemoBD();
                List<DemoMenu> oMenus = oBaseDemo.DemoMenu.ToList();
                foreach (DemoMenu m in oMenus) {
                    Models.ModelMenu oNewMenu = new Models.ModelMenu();
                    oNewMenu.MenuCodigo = m.MenuCodigo;
                    oNewMenu.MenuDescripcion = m.MenuDescripcion;
                    oRes.Add(oNewMenu);
                }
            }
            catch (Exception ex) { }
            return oRes;
        }

        public List<Models.ModelProducto> GetProducts([FromBody] string sMenu)
        {
            List<Models.ModelProducto> oRes = new List<Models.ModelProducto>();
            try
            {
                DemoBD oBaseDemo = new DemoBD();
                DemoMenu oMenu = oBaseDemo.DemoMenu.Where(s=> s.MenuCodigo==sMenu).First();
                foreach (DemoProduct p in oMenu.DemoProduct.ToList())
                {
                    Models.ModelProducto oNewPro = new Models.ModelProducto();
                    oNewPro.ProductCodigo = p.ProductCodigo;
                    oNewPro.ProductDescripcion = p.ProductDescripcion;
                    oNewPro.ProductPrecio = p.ProductPrecio;
                    oNewPro.ProductTitulo = p.ProductTitulo;
                    oNewPro.ProductComplementos = false;
                    if (p.DemoTipoCom.Count > 0)
                        oNewPro.ProductComplementos = true;
                    oRes.Add(oNewPro);
                }
            }
            catch (Exception ex) { }
            return oRes;
        }

        public List<Models.ModelTipoComplemento> GetComplementos([FromBody] string sProduct)
        {
            List<Models.ModelTipoComplemento> oRes = new List<Models.ModelTipoComplemento>();
            try
            {
                DemoBD oBaseDemo = new DemoBD();
                DemoProduct oProduct = oBaseDemo.DemoProduct.Where(s => s.ProductCodigo == sProduct).First();
                foreach (DemoTipoCom t in oProduct.DemoTipoCom.ToList())
                {
                    Models.ModelTipoComplemento oNewTipo = new Models.ModelTipoComplemento();
                    oNewTipo.TipoCodigo = t.TipoCodigo;
                    oNewTipo.TipoDescripcion = t.TipoDescripcion;
                    oNewTipo.TipoMaxCantidad = t.TipoMaxCantidad;
                    oNewTipo.TipoOrden = t.TipoOrden;

                    foreach (DemoComplemento c in t.DemoComplemento.ToList()) {
                        Models.ModelComplemento oNewCom = new Models.ModelComplemento();
                        oNewCom.ComplementoCantidad = 0;
                        oNewCom.ComplementoCodigo = c.ComplementoCodigo;
                        oNewCom.ComplementoDescripcion = c.ComplementoDescripcion;
                        oNewCom.ComplementoPrecio = c.ComplementoPrecio;
                        oNewCom.ComplementoSeleccionado = false;
                        oNewTipo.Complementos.Add(oNewCom);
                    }
                    oRes.Add(oNewTipo);
                }
            }
            catch (Exception ex) { }
            return oRes;
        }

        public string GetOrden([FromBody] Models.ModelCanasta oCanasta) {
            string sRes = string.Empty;
            try
            {
                //Guardamos Orden Header
                DemoBD oBaseDemo = new DemoBD();
                DemoOrdenHeader oOrden = new DemoOrdenHeader();
                oOrden.OrdenCanal = oCanasta.Canal;
                oOrden.OrdenCantidad = oCanasta.Cantidad;
                oOrden.OrdenTotal = oCanasta.Total;
                //Guardamos los productos de la orden
                foreach (Models.ModelProducto p in oCanasta.Items){
                    DemoOrdenContent oContent = new DemoOrdenContent();
                    oContent.OrdenCantidad = p.ProductCantidad;
                    oContent.OrdenProduct = p.ProductCodigo;
                    oContent.OrdenTotal = p.ProductTotal;
                    if (p.ProductComplementos) {
                        foreach (Models.ModelComplemento c in p.ProductComplementosElegidos)
                        {
                            if (c.ComplementoCantidad > 0) {
                                DemoOrdenContentComplemento oComple = new DemoOrdenContentComplemento();
                                oComple.OrdenComplemento = c.ComplementoCodigo;
                                oComple.OrdenComplementoCantidad = c.ComplementoCantidad;
                                oComple.OrdenComplementoPrecio = c.ComplementoPrecio;
                                oComple.OrdenComplementoTotal = (c.ComplementoPrecio * c.ComplementoCantidad);
                                oContent.DemoOrdenContentComplemento.Add(oComple);
                            }
                        }
                    }
                    oOrden.DemoOrdenContent.Add(oContent);
                }
                //Guardar la orden en base de datos y obtenerla
                oBaseDemo.DemoOrdenHeader.Add(oOrden);
                oBaseDemo.SaveChanges();
                sRes = oBaseDemo.DemoOrdenHeader.Max(s => s.Orden).ToString();
            }
            catch (Exception ex) {

            }
            return sRes;
        }

    }
}
