using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto2_1.Models;

namespace proyecto2_1.Controllers
{
    [Authorize]
    public class IdiomasController : Controller
    {
        private DB_BibliotecaEntities db = new DB_BibliotecaEntities();

        // GET: Idiomas
        public ActionResult Index()
        {
            return View(db.Idioma.ToList());
        }

        // GET: Idiomas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = db.Idioma.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        // GET: Idiomas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idiomas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Idioma,Idioma1")] Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                db.Idioma.Add(idioma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idioma);
        }

        // GET: Idiomas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = db.Idioma.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        // POST: Idiomas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Idioma,Idioma1")] Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idioma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idioma);
        }

        // GET: Idiomas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = db.Idioma.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        // POST: Idiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idioma idioma = db.Idioma.Find(id);
            db.Idioma.Remove(idioma);
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
