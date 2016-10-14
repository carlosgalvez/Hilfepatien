using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Puesto { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Sueldo { get; set; }

    }
    }
