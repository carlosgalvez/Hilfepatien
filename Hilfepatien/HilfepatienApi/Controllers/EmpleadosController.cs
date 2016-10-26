using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;

namespace HilfepatienApi.Controllers
{
    public class EmpleadosController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();
        // GET api/empleados

        public List<Empleados> Get()
        {
            return db.Empleados.ToList();
        }

        // GET api/empleados/5
        public List<Empleados>Get(int Id)
        {
            return db.Empleados.where(e=> e.Id==Id).ToList();
        }

        // POST api/empleados
        public bool Post(int Id, string Nombre,string Puesto,DateTime Fecha_Ingreso,int Sueldo)
        {
            var e = new Empleados
            {
                Id = Id,
                Nombre = Nombre,
                Puesto = Puesto,
                Fecha_Ingreso = Fecha_Ingreso,
                Sueldo = Sueldo



            };
            db.Empleados.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/empleados/5
        public bool Put(string Nombre, string Puesto, DateTime Fecha_Ingreso, int Sueldo)
        {
            var Empleados = new Empleados
            {
                Nombre = Nombre,
                Puesto = Puesto,
                Fecha_Ingreso = Fecha_Ingreso,
                Sueldo = Sueldo
            };

            db.Empleados.Add(Empleados);
            return db.SaveChanges() > 0;
        }

        // DELETE api/empleados/5
        public void Delete(int Id)
        {
            var e = db.Empleados.Find(Id);
            db.Empleados.Attach(e);
            db.Empleados.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
