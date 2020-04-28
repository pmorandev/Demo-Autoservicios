using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaz;

namespace Demo.Interfaz.Controllers
{
    public class DemoTipoComsController : Controller
    {
        private DemoBD db = new DemoBD();

        // GET: DemoTipoComs
        public ActionResult Index()
        {
            var demoTipoCom = db.DemoTipoCom.Include(d => d.DemoProduct);
            return View(demoTipoCom.ToList());
        }

        // GET: DemoTipoComs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTipoCom demoTipoCom = db.DemoTipoCom.Find(id);
            if (demoTipoCom == null)
            {
                return HttpNotFound();
            }
            return View(demoTipoCom);
        }

        // GET: DemoTipoComs/Create
        public ActionResult Create()
        {
            ViewBag.TipoProduct = new SelectList(db.DemoProduct, "ProductCodigo", "ProductDescripcion");
            return View();
        }

        // POST: DemoTipoComs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoCodigo,TipoDescripcion,TipoMaxCantidad,TipoCantidad,TipoOrden,TipoProduct")] DemoTipoCom demoTipoCom)
        {
            if (ModelState.IsValid)
            {
                db.DemoTipoCom.Add(demoTipoCom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoProduct = new SelectList(db.DemoProduct, "ProductCodigo", "ProductDescripcion", demoTipoCom.TipoProduct);
            return View(demoTipoCom);
        }

        // GET: DemoTipoComs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTipoCom demoTipoCom = db.DemoTipoCom.Find(id);
            if (demoTipoCom == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoProduct = new SelectList(db.DemoProduct, "ProductCodigo", "ProductDescripcion", demoTipoCom.TipoProduct);
            return View(demoTipoCom);
        }

        // POST: DemoTipoComs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoCodigo,TipoDescripcion,TipoMaxCantidad,TipoCantidad,TipoOrden,TipoProduct")] DemoTipoCom demoTipoCom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoTipoCom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoProduct = new SelectList(db.DemoProduct, "ProductCodigo", "ProductDescripcion", demoTipoCom.TipoProduct);
            return View(demoTipoCom);
        }

        // GET: DemoTipoComs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTipoCom demoTipoCom = db.DemoTipoCom.Find(id);
            if (demoTipoCom == null)
            {
                return HttpNotFound();
            }
            return View(demoTipoCom);
        }

        // POST: DemoTipoComs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DemoTipoCom demoTipoCom = db.DemoTipoCom.Find(id);
            db.DemoTipoCom.Remove(demoTipoCom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
