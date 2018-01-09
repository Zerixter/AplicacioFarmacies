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
    public class FarmaciasController : Controller
    {
        private FarmaciaContext db = new FarmaciaContext();

        // GET: Farmacias
        public ActionResult Index()
        {
            var farmacies = db.Farmacies.Include(f => f.Poblacio);
            return View(farmacies.ToList());
        }

        // GET: Farmacias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacia farmacia = db.Farmacies.Find(id);
            if (farmacia == null)
            {
                return HttpNotFound();
            }
            List<Comentari> Comentaris = db.Comentaris.Where(x => x.IdFarmacia == id).ToList();

            ViewBag.Comentaris = Comentaris;
            ViewBag.Farmacia = farmacia;
            return View(farmacia);
        }

        // GET: Farmacias/Create
        public ActionResult Create()
        {
            ViewBag.IdPoblacio = new SelectList(db.Poblacions, "IdPoblacio", "NomPoblacio");
            return View();
        }

        // POST: Farmacias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFarmacia,CodiFarmacia,NomFarmacia,TipusVia,Carrer,NumeroVia,NumeroTelefon,AreaBasicaSalut,IdPoblacio")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                db.Farmacies.Add(farmacia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPoblacio = new SelectList(db.Poblacions, "IdPoblacio", "NomPoblacio", farmacia.IdPoblacio);
            return View(farmacia);
        }

        // GET: Farmacias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacia farmacia = db.Farmacies.Find(id);
            if (farmacia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPoblacio = new SelectList(db.Poblacions, "IdPoblacio", "NomPoblacio", farmacia.IdPoblacio);
            return View(farmacia);
        }

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFarmacia,CodiFarmacia,NomFarmacia,TipusVia,Carrer,NumeroVia,NumeroTelefon,AreaBasicaSalut,IdPoblacio")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmacia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPoblacio = new SelectList(db.Poblacions, "IdPoblacio", "NomPoblacio", farmacia.IdPoblacio);
            return View(farmacia);
        }

        // GET: Farmacias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacia farmacia = db.Farmacies.Find(id);
            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmacia farmacia = db.Farmacies.Find(id);
            db.Farmacies.Remove(farmacia);
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
