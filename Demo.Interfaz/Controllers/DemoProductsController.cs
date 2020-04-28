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
    public class DemoProductsController : Controller
    {
        private DemoBD db = new DemoBD();

        // GET: DemoProducts
        public ActionResult Index()
        {
            var demoProduct = db.DemoProduct.Include(d => d.DemoMenu);
            return View(demoProduct.ToList());
        }

        // GET: DemoProducts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoProduct demoProduct = db.DemoProduct.Find(id);
            if (demoProduct == null)
            {
                return HttpNotFound();
            }
            return View(demoProduct);
        }

        // GET: DemoProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductMenu = new SelectList(db.DemoMenu, "MenuCodigo", "MenuDescripcion");
            return View();
        }

        // POST: DemoProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCodigo,ProductCantidad,ProductDescripcion,ProductPrecio,ProductTotal,ProductTitulo,ProductComplementos,ProductMenu")] DemoProduct demoProduct)
        {
            if (ModelState.IsValid)
            {
                db.DemoProduct.Add(demoProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductMenu = new SelectList(db.DemoMenu, "MenuCodigo", "MenuDescripcion", demoProduct.ProductMenu);
            return View(demoProduct);
        }

        // GET: DemoProducts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoProduct demoProduct = db.DemoProduct.Find(id);
            if (demoProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductMenu = new SelectList(db.DemoMenu, "MenuCodigo", "MenuDescripcion", demoProduct.ProductMenu);
            return View(demoProduct);
        }

        // POST: DemoProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCodigo,ProductCantidad,ProductDescripcion,ProductPrecio,ProductTotal,ProductTitulo,ProductComplementos,ProductMenu")] DemoProduct demoProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductMenu = new SelectList(db.DemoMenu, "MenuCodigo", "MenuDescripcion", demoProduct.ProductMenu);
            return View(demoProduct);
        }

        // GET: DemoProducts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoProduct demoProduct = db.DemoProduct.Find(id);
            if (demoProduct == null)
            {
                return HttpNotFound();
            }
            return View(demoProduct);
        }

        // POST: DemoProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DemoProduct demoProduct = db.DemoProduct.Find(id);
            db.DemoProduct.Remove(demoProduct);
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
