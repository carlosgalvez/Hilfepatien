using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;


namespace HilfepatienApi.Controllers
{
    public class ProveedorController : ApiController
    {
          private HilfepatienContext db = new HilfepatienContext();
        // GET api/proveedor
        public List<Proveedor> Get()
        {
            return db.Proveedores.ToList();
        }
        // GET api/proveedor/5
        public List<Proveedor> Get(int Id )
        {
            return db.Proveedores.Where(e => e.Id == Id).ToList();
        }

        // POST api/proveedor
        public bool Post(int Id, string Nombre, int Telefono, string Direccion, int MedicinaId)
        {
            var e = new Proveedor
            {
                Id = Id,
                Nombre = Nombre,
                Telefono = Telefono,
                Direccion = Direccion,
                MedicinaId = MedicinaId

            };
            db.Proveedores.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/proveedor/5
        public bool Put(string Nombre, int Telefono, string Direccion, int MedicinaId)
        {

            var Proveedor = new Proveedor
            {
                Nombre = Nombre,
                Telefono = Telefono,
                Direccion = Direccion,
                MedicinaId = MedicinaId

            };
            db.Proveedores.Add(Proveedor);
            return db.SaveChanges() > 0;

        }

        // DELETE api/proveedor/5
        public bool Delete(int Id)
        {
            var e = db.Proveedores.Find(Id);
            db.Proveedores.Attach(e);
            db.Proveedores.Remove(e);
            return db.SaveChanges() > 0;

        }
    }
}
