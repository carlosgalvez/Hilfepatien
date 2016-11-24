using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;

namespace HilfepatienApi.Controllers
{
    public class RecetaController : ApiController
    {
        private IEnumerable<Receta> Recetas = new List<Receta>
        {


        };

        private HilfepatienContext db = new HilfepatienContext();
        // GET api/receta
        public List<Receta> Get()
        {
            return db.Recetas.ToList();
        }

        // GET api/receta/5
        public List<Receta> Get(int Id)
        {
            return db.Recetas.Where(e => e.Id == Id).ToList();
        }

        // POST api/receta
        public bool Post(int Id, String Tipo_Medicamento, String Nombre_Medicamento, String Nombre_Paciente, DateTime Fecha,int Paciente_Id)
        {
            var e = new Receta
            {
                Id = Id,
                Tipo_Medicamento = Tipo_Medicamento,
                Nombre_Medicamento = Nombre_Medicamento,
                Nombre_Paciente = Nombre_Paciente,
   
                Fecha = Fecha 
               
               
            };
            db.Recetas.Attach(e);

            db.Entry(e).State = System.Data.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/receta/5
        public bool Put(String Tipo_Medicamento, String Nombre_Medicamento, String Nombre_Paciente, DateTime Fecha)
        {
            var Receta = new Receta
            {
                Tipo_Medicamento = Tipo_Medicamento,
                Nombre_Medicamento = Nombre_Medicamento,
                Nombre_Paciente = Nombre_Paciente,
                Fecha = Fecha
                
            };
            db.Recetas.Add(Receta);
            return db.SaveChanges() > 0;
        }

        // DELETE api/receta/5
        public bool Delete(int Id)
        {
            var e = db.Recetas.Find(Id);
            db.Recetas.Attach(e);
            db.Recetas.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
