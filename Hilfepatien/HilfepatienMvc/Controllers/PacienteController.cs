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
    public class PacienteController : Controller
    {
        private HilfepatienContext db = new HilfepatienContext();

        //
        // GET: /Paciente/

        public ActionResult Index()
        {
            return View(db.Pacientes.ToList());
        }

        //
        // GET: /Paciente/Details/5

        public ActionResult Details(int id = 0)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        //
        // GET: /Paciente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Paciente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        //
        // GET: /Paciente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        //
        // POST: /Paciente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        //
        // GET: /Paciente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        //
        // POST: /Paciente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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