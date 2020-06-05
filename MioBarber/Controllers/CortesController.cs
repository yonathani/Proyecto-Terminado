using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MioBarber.Models;

namespace MioBarber.Controllers
{
    public class CortesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cortes
        public ActionResult Index()
        {
            return View(db.Cortes.ToList());
        }

        // GET: Cortes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corte corte = db.Cortes.Find(id);
            if (corte == null)
            {
                return HttpNotFound();
            }
            return View(corte);
        }

        // GET: Cortes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cortes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price")] Corte corte)
        {
            if (ModelState.IsValid)
            {
                db.Cortes.Add(corte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(corte);
        }

        // GET: Cortes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corte corte = db.Cortes.Find(id);
            if (corte == null)
            {
                return HttpNotFound();
            }
            return View(corte);
        }

        // POST: Cortes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] Corte corte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(corte);
        }

        // GET: Cortes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corte corte = db.Cortes.Find(id);
            if (corte == null)
            {
                return HttpNotFound();
            }
            return View(corte);
        }

        // POST: Cortes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Corte corte = db.Cortes.Find(id);
            db.Cortes.Remove(corte);
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
