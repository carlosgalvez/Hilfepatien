using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HilfepatienApi.Controllers
{
    public class MedicoController : ApiController
    {
        // GET api/medico
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/medico/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/medico
        public void Post([FromBody]string value)
        {
        }

        // PUT api/medico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/medico/5
        public void Delete(int id)
        {
        }
    }
}
