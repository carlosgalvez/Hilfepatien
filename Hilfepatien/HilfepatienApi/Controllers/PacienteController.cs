﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HilfepatienApi.Controllers
{
    public class PacienteController : ApiController
    {
        // GET api/paciente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/paciente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/paciente
        public void Post([FromBody]string value)
        {
        }

        // PUT api/paciente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/paciente/5
        public void Delete(int id)
        {
        }
    }
}
