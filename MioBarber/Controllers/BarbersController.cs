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
    public class BarbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Barbers
        public ActionResult Index()
        {
            var barbers = db.Barbers.Include(b => b.Horario);
            return View(barbers.ToList());
        }

        // GET: Barbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // GET: Barbers/Create
        public ActionResult Create()
        {
            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Time");
            return View();
        }

        // POST: Barbers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Description,HorarioId,Phone")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                db.Barbers.Add(barber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Time", barber.HorarioId);
            return View(barber);
        }

        // GET: Barbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Time", barber.HorarioId);
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Description,HorarioId,Phone")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Time", barber.HorarioId);
            return View(barber);
        }

        // GET: Barbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barber barber = db.Barbers.Find(id);
            db.Barbers.Remove(barber);
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
