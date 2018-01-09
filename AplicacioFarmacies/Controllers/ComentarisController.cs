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
    public class ComentarisController : Controller
    {
        private FarmaciaContext db = new FarmaciaContext();

        // GET: Comentaris
        public ActionResult Index()
        {
            var comentaris = db.Comentaris.Include(c => c.Farmacia);
            return View(comentaris.ToList());
        }

        // GET: Comentaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentari comentari = db.Comentaris.Find(id);
            if (comentari == null)
            {
                return HttpNotFound();
            }
            return View(comentari);
        }

        // GET: Comentaris/Create
        public ActionResult Create()
        {
            ViewBag.IdFarmacia = new SelectList(db.Farmacies, "IdFarmacia", "CodiFarmacia");
            return View();
        }

        // GET: 
        [HttpGet]
        [Route("Comentaris/CreateByIdFarmacia/{id_farmacia:int}", Name = "Crear_Comentaris_Per_Farmacia")]
        public ActionResult CreateByIdFarmacia(int id_farmacia)
        {
            Farmacia farmacia = db.Farmacies.Find(id_farmacia);
            ViewBag.Farmacia = farmacia;
            return View();
        }

        [HttpPost]
        public ActionResult CreateByIdFarmacia([Bind(Include = "IdComentari, NomAutorComentari, ContingutComentariIdFarmacia")] Comentari comentari)
        {
            return View();
        }
       

        // POST: Comentaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComentari,NomAutorComentari,ContingutComentari,IdFarmacia")] Comentari comentari)
        {
            if (ModelState.IsValid)
            {
                db.Comentaris.Add(comentari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFarmacia = new SelectList(db.Farmacies, "IdFarmacia", "CodiFarmacia", comentari.IdFarmacia);
            return View(comentari);
        }

        // GET: Comentaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentari comentari = db.Comentaris.Find(id);
            if (comentari == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFarmacia = new SelectList(db.Farmacies, "IdFarmacia", "CodiFarmacia", comentari.IdFarmacia);
            return View(comentari);
        }

        // POST: Comentaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentari,NomAutorComentari,ContingutComentari,IdFarmacia")] Comentari comentari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFarmacia = new SelectList(db.Farmacies, "IdFarmacia", "CodiFarmacia", comentari.IdFarmacia);
            return View(comentari);
        }

        // GET: Comentaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentari comentari = db.Comentaris.Find(id);
            if (comentari == null)
            {
                return HttpNotFound();
            }
            return View(comentari);
        }

        // POST: Comentaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentari comentari = db.Comentaris.Find(id);
            db.Comentaris.Remove(comentari);
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
