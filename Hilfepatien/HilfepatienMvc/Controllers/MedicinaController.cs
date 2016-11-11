
using HilfepatienMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HilfepatienMvc.Controllers
{
    public class MedicinaController : Controller
    {
      public  HilfepatienContext db = new HilfepatienContext();
        
        //
        // GET: /Medicina/

        public ActionResult Index()
        {
           
            
            List<Medicina> lmedicina = new List<Medicina>();
            Medicina m1 = new Medicina();
            m1.Id = 1;
            m1.IdProveedor = 1;
            m1.Nombre = "Paracetamol 500 mg";
            m1.Presentacion = "Caja 20 capsulas";
            m1.TipodeMedicamento="Controlados";
            lmedicina.Add(m1);
            Medicina m2 = new Medicina();
            m2.Id = 2;
            m2.IdProveedor = 1;
            m2.Nombre = "Naproxeo 500 mg";
            m2.Presentacion = "Caja 12 tabletas";
            m2.TipodeMedicamento = "Controlados";
            lmedicina.Add(m2);  
           
            return View(lmedicina);
        }

        //
        // GET: /Medicina/Details/5

        public ActionResult Details(int id)
        {
           
           return View(db.Medicinas.Where(e=> e.Id==id));
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
        public ActionResult Create(Medicina medicina)
        {
            try
            {
                db.Medicinas.Add(medicina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                
                return View("Create");
            }
        }

        //
        // GET: /Medicina/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Medicina/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Medicina/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Medicina/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
