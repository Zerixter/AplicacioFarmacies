using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacioFarmacies.Models;

namespace AplicacioFarmacies.Controllers
{
    public class PoblaciosController : Controller
    {
        private FarmaciaContext db = new FarmaciaContext();

        // GET: Poblacios
        public ActionResult Index()
        {
            var poblacions = db.Poblacions.Include(p => p.Provincia);
            return View(poblacions.ToList());
        }

        // GET: Poblacios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poblacio poblacio = db.Poblacions.Find(id);
            if (poblacio == null)
            {
                return HttpNotFound();
            }
            return View(poblacio);
        }

        // GET: Poblacios/Create
        public ActionResult Create()
        {
            ViewBag.IdProvincia = new SelectList(db.Provincies, "IdProvincia", "NomProvincia");
            return View();
        }

        // POST: Poblacios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPoblacio,NomPoblacio,CP,IdProvincia")] Poblacio poblacio)
        {
            if (ModelState.IsValid)
            {
                db.Poblacions.Add(poblacio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProvincia = new SelectList(db.Provincies, "IdProvincia", "NomProvincia", poblacio.IdProvincia);
            return View(poblacio);
        }

        // GET: Poblacios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poblacio poblacio = db.Poblacions.Find(id);
            if (poblacio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProvincia = new SelectList(db.Provincies, "IdProvincia", "NomProvincia", poblacio.IdProvincia);
            return View(poblacio);
        }

        // POST: Poblacios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPoblacio,NomPoblacio,CP,IdProvincia")] Poblacio poblacio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poblacio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProvincia = new SelectList(db.Provincies, "IdProvincia", "NomProvincia", poblacio.IdProvincia);
            return View(poblacio);
        }

        // GET: Poblacios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poblacio poblacio = db.Poblacions.Find(id);
            if (poblacio == null)
            {
                return HttpNotFound();
            }
            return View(poblacio);
        }

        // POST: Poblacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poblacio poblacio = db.Poblacions.Find(id);
            db.Poblacions.Remove(poblacio);
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
