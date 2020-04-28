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
    public class DemoComplementoesController : Controller
    {
        private DemoBD db = new DemoBD();

        // GET: DemoComplementoes
        public ActionResult Index()
        {
            var demoComplemento = db.DemoComplemento.Include(d => d.DemoTipoCom);
            return View(demoComplemento.ToList());
        }

        // GET: DemoComplementoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoComplemento demoComplemento = db.DemoComplemento.Find(id);
            if (demoComplemento == null)
            {
                return HttpNotFound();
            }
            return View(demoComplemento);
        }

        // GET: DemoComplementoes/Create
        public ActionResult Create()
        {
            ViewBag.ComplementoTipo = new SelectList(db.DemoTipoCom, "TipoCodigo", "TipoDescripcion");
            return View();
        }

        // POST: DemoComplementoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplementoCodigo,ComplementoTipo,ComplementoPrecio,ComplementoDescripcion")] DemoComplemento demoComplemento)
        {
            if (ModelState.IsValid)
            {
                db.DemoComplemento.Add(demoComplemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplementoTipo = new SelectList(db.DemoTipoCom, "TipoCodigo", "TipoDescripcion", demoComplemento.ComplementoTipo);
            return View(demoComplemento);
        }

        // GET: DemoComplementoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoComplemento demoComplemento = db.DemoComplemento.Find(id);
            if (demoComplemento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplementoTipo = new SelectList(db.DemoTipoCom, "TipoCodigo", "TipoDescripcion", demoComplemento.ComplementoTipo);
            return View(demoComplemento);
        }

        // POST: DemoComplementoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplementoCodigo,ComplementoTipo,ComplementoPrecio,ComplementoDescripcion")] DemoComplemento demoComplemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoComplemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplementoTipo = new SelectList(db.DemoTipoCom, "TipoCodigo", "TipoDescripcion", demoComplemento.ComplementoTipo);
            return View(demoComplemento);
        }

        // GET: DemoComplementoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoComplemento demoComplemento = db.DemoComplemento.Find(id);
            if (demoComplemento == null)
            {
                return HttpNotFound();
            }
            return View(demoComplemento);
        }

        // POST: DemoComplementoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DemoComplemento demoComplemento = db.DemoComplemento.Find(id);
            db.DemoComplemento.Remove(demoComplemento);
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
