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
    public class DemoMenusController : Controller
    {
        private DemoBD db = new DemoBD();

        // GET: DemoMenus
        public ActionResult Index()
        {
            return View(db.DemoMenu.ToList());
        }

        // GET: DemoMenus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoMenu demoMenu = db.DemoMenu.Find(id);
            if (demoMenu == null)
            {
                return HttpNotFound();
            }
            return View(demoMenu);
        }

        // GET: DemoMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemoMenus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuCodigo,MenuDescripcion")] DemoMenu demoMenu)
        {
            if (ModelState.IsValid)
            {
                db.DemoMenu.Add(demoMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demoMenu);
        }

        // GET: DemoMenus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoMenu demoMenu = db.DemoMenu.Find(id);
            if (demoMenu == null)
            {
                return HttpNotFound();
            }
            return View(demoMenu);
        }

        // POST: DemoMenus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuCodigo,MenuDescripcion")] DemoMenu demoMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demoMenu);
        }

        // GET: DemoMenus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoMenu demoMenu = db.DemoMenu.Find(id);
            if (demoMenu == null)
            {
                return HttpNotFound();
            }
            return View(demoMenu);
        }

        // POST: DemoMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DemoMenu demoMenu = db.DemoMenu.Find(id);
            db.DemoMenu.Remove(demoMenu);
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
