using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;


namespace HilfepatienApi.Controllers
{
    public class PacienteController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();
        // GET api/paciente
        public List<Paciente> Get()
        {
            return db.Pacientes.ToList();
        }

        // GET api/paciente/5
        public List<Paciente>Get(int Id)
        {
            return db.Pacientes.Where(e=> e.Id==Id).ToList();
        }

        // POST api/paciente
        public bool Post(int Id,string Nombre,string Apellido,string Sexo,int Edad,string Direccion, int Telefono)
        {
            var e = new Paciente
            {
                Id=Id,
                Nombre=Nombre,
                Apellido=Apellido,
                Sexo=Sexo,
                Edad=Edad,
                Direccion=Direccion,
                Telefono=Telefono

            };
            db.Pacientes.Attach(e);
            db.Entry(e).State = System.Data.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/paciente/5
        public bool Put(string Nombre,string Apellido,string Sexo,int Edad,string Direccion, int Telefono)
        {
            var Paciente = new Paciente
            {
                Nombre=Nombre,
                Apellido=Apellido,
                Sexo=Sexo,
                Edad=Edad,
                Direccion=Direccion,
                Telefono=Telefono

            };
            db.Pacientes.Add(Paciente);
            return db.SaveChanges() > 0;
        }

        // DELETE api/paciente/5
        public bool Delete(int Id)
        {
            var e=db.Pacientes.Find(Id);
            db.Pacientes.Attach(e);
            db.Pacientes.Remove(e);
            return db.SaveChanges()>0;
        }
    }
}
