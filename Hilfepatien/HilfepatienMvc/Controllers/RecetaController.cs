﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HilfepatienMvc.Models;

namespace HilfepatienMvc.Controllers
{
    public class RecetaController : Controller
    {
        private HilfepatienContext db = new HilfepatienContext();

        //
        // GET: /Receta/

        public ActionResult Index()
        {
            return View(db.Recetas.ToList());
        }

        //
        // GET: /Receta/Details/5

        public ActionResult Details(int id = 0)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // GET: /Receta/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Receta/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Recetas.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receta);
        }

        //
        // GET: /Receta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // POST: /Receta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receta);
        }

        //
        // GET: /Receta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // POST: /Receta/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = db.Recetas.Find(id);
            db.Recetas.Remove(receta);
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