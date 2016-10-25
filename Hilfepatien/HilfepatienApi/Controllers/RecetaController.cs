using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HilfepatienApi.Controllers
{
    public class RecetaController : ApiController
    {
        // GET api/receta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/receta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/receta
        public void Post([FromBody]string value)
        {
        }

        // PUT api/receta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/receta/5
        public void Delete(int id)
        {
        }
    }
}
