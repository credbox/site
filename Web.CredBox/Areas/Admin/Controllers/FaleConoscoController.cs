using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class FaleConoscoController : BaseController
    {
        // GET api/faleconosco
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/faleconosco/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/faleconosco
        public void Post([FromBody]string value)
        {
        }

        // PUT api/faleconosco/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/faleconosco/5
        public void Delete(int id)
        {
        }
    }
}
