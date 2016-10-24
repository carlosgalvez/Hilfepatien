using HilfepatienApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienMvc.Models
{
    public class Medicina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProveedor { get; set; }
        public string Presentacion { get; set; }
        public string TipodeMedicamento { get; set; }
        public virtual ICollection<Proveedor>Proveedor{ get; set; }

    }
}