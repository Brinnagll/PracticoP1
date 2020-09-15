using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmGorena.Models;

namespace AdmGorena.Controllers
{
    public class GorenasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Gorenas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Gorenas.ToList());
        }

        // GET: Gorenas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorena gorena = db.Gorenas.Find(id);
            if (gorena == null)
            {
                return HttpNotFound();
            }
            return View(gorena);
        }

        // GET: Gorenas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gorenas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GorenaID,FriendOfGorena,Place,Email,Birthdate")] Gorena gorena)
        {
            if (ModelState.IsValid)
            {
                db.Gorenas.Add(gorena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gorena);
        }

        // GET: Gorenas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorena gorena = db.Gorenas.Find(id);
            if (gorena == null)
            {
                return HttpNotFound();
            }
            return View(gorena);
        }

        // POST: Gorenas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GorenaID,FriendOfGorena,Place,Email,Birthdate")] Gorena gorena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gorena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gorena);
        }

        // GET: Gorenas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorena gorena = db.Gorenas.Find(id);
            if (gorena == null)
            {
                return HttpNotFound();
            }
            return View(gorena);
        }

        // POST: Gorenas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gorena gorena = db.Gorenas.Find(id);
            db.Gorenas.Remove(gorena);
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
