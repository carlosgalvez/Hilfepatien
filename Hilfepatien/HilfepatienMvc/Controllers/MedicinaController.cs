using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HilfepatienMvc.Models;

namespace HilfepatienMvc.Controllers
{
    public class MedicinaController : Controller
    {
        private HilfepatienContext db = new HilfepatienContext();

        //
        // GET: /Medicina/

        public ActionResult Index()
        {
            return View(db.Medicinas.ToList());
        }

        //
        // GET: /Medicina/Details/5

        public ActionResult Details(int id = 0)
        {
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        //
        // GET: /Medicina/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Medicina/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                db.Medicinas.Add(medicina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicina);
        }

        //
        // GET: /Medicina/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        //
        // POST: /Medicina/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicina);
        }

        //
        // GET: /Medicina/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        //
        // POST: /Medicina/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicina medicina = db.Medicinas.Find(id);
            db.Medicinas.Remove(medicina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}