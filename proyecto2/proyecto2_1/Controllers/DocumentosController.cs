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
    public class DocumentosController : Controller
    {
        private DB_BibliotecaEntities db = new DB_BibliotecaEntities();
        [AllowAnonymous]
        // GET: Documentos
        public ActionResult Index()
        {
            var documento = db.Documento.Include(d => d.Autores).Include(d => d.Categoria).Include(d => d.Idioma1);
            return View(documento.ToList());
        }
        [AllowAnonymous]
        // GET: Documentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            ViewBag.Autor = new SelectList(db.Autores, "Id_Autor", "Autor");
            ViewBag.Categoría = new SelectList(db.Categoria, "Id_Categoria", "Categoría");
            ViewBag.Idioma = new SelectList(db.Idioma, "Id_Idioma", "Idioma1");
            return View();
        }

        // POST: Documentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Documento,Titulo,Fecha_de_Lanzamiento,Autor,Categoría,Idioma,No_Paginas,Descripcion,Disponibilidad")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Documento.Add(documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Autor = new SelectList(db.Autores, "Id_Autor", "Autor", documento.Autor);
            ViewBag.Categoría = new SelectList(db.Categoria, "Id_Categoria", "Categoría", documento.Categoría);
            ViewBag.Idioma = new SelectList(db.Idioma, "Id_Idioma", "Idioma1", documento.Idioma);
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Autor = new SelectList(db.Autores, "Id_Autor", "Autor", documento.Autor);
            ViewBag.Categoría = new SelectList(db.Categoria, "Id_Categoria", "Categoría", documento.Categoría);
            ViewBag.Idioma = new SelectList(db.Idioma, "Id_Idioma", "Idioma1", documento.Idioma);
            return View(documento);
        }

        // POST: Documentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Documento,Titulo,Fecha_de_Lanzamiento,Autor,Categoría,Idioma,No_Paginas,Descripcion,Disponibilidad")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Autor = new SelectList(db.Autores, "Id_Autor", "Autor", documento.Autor);
            ViewBag.Categoría = new SelectList(db.Categoria, "Id_Categoria", "Categoría", documento.Categoría);
            ViewBag.Idioma = new SelectList(db.Idioma, "Id_Idioma", "Idioma1", documento.Idioma);
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documento documento = db.Documento.Find(id);
            db.Documento.Remove(documento);
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
