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
    public class AutoresController : Controller
    {
        private DB_BibliotecaEntities db = new DB_BibliotecaEntities();

        // GET: Autores
        public ActionResult Index()
        {
            return View(db.Autores.ToList());
        }

        // GET: Autores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Autor,Autor,Apellido")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Add(autores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autores);
        }

        // GET: Autores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // POST: Autores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Autor,Autor,Apellido")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autores);
        }

        // GET: Autores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autores autores = db.Autores.Find(id);
            db.Autores.Remove(autores);
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
