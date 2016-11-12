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
    public class EmpleadosController : Controller
    {
        private HilfepatienContext db = new HilfepatienContext();

        //
        // GET: /Empleados/

        public ActionResult Index()
        {
            return View(db.Empleados.ToList());
        }

        //
        // GET: /Empleados/Details/5

        public ActionResult Details(int id = 0)
        {
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        //
        // GET: /Empleados/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Empleados/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        //
        // GET: /Empleados/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        //
        // POST: /Empleados/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        //
        // GET: /Empleados/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        //
        // POST: /Empleados/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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