using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;

namespace HilfepatienApi.Controllers
{
    public class MedicinaController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();
        // GET api/medicina
        public List <Medicina> Get()
        {
            return db.Medicinas.ToList();
       
        }

        // GET api/medicina/5
        public List<Medicina> Get(int Id)
        {
            return db.Medicinas.where(e => e.Id==Id).Tolist();
        }

        // POST api/medicina
        public bool Post(int Id, string Nombre, int IdProveedor, string presentacion, string TipodeMedicamento)
        {
            var e = new Medicina
            {
                Id = Id,
                Nombre = Nombre,
                IdProveedor = IdProveedor,
                Presentacion = presentacion,
                TipodeMedicamento = TipodeMedicamento

            };
            db.Medicinas.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;

        }

        // PUT api/medicina/5
        public bool Put(string Nombre, int IdProveedor, string presentacion, string TipodeMedicamento)
        {
           var Medicina=new Medicina
           {
               Nombre=Nombre,
               IdProveedor=IdProveedor,
               Presentacion=presentacion,
               TipodeMedicamento=TipodeMedicamento
           };
            db.Medicinas.Add(Medicina);
             return db.SaveChanges() > 0;
        }

        // DELETE api/medicina/5
        public void Delete(int Id)
        {
            var e = db.Medicinas.find(Id);
            db.Medicinas.Attach(e);
            db.Medicinas.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
