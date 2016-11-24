using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;

namespace HilfepatienApi.Controllers
{
    public class MedicoController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();
        // GET api/medico
        public List<Medico> Get()
        {
            return db.Medicos.ToList();
        }

        // GET api/medico/5
        public List<Medico>Get(int Id)
        {
            return db.Medicos.Where(e => e.Id == Id).ToList();
        }

        // POST api/medico
        public bool Post(int Id, string Nombre, string Apellido,string Especialidad, int Telefono)
        {
            var e = new Medico
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                Especialidad = Especialidad,
                Telefono = Telefono
            };

            db.Medicos.Attach(e);
            db.Entry(e).State = System.Data.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;


        }

        // PUT api/medico/5
        public bool Put(string Nombre, string Apellido, string Especialidad, int Telefono)
        {
            var Medico = new Medico
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Especialidad = Especialidad,
                Telefono = Telefono
            };
            db.Medicos.Add(Medico);
            return db.SaveChanges() > 0;
        }

        // DELETE api/medico/5
        public bool Delete(int Id)
        {
            var e = db.Medicos.Find(Id);
            db.Medicos.Attach(e);
            db.Medicos.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
