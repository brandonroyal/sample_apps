using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class HealthController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpStatusCode Index()
        {
            return HttpStatusCode.OK;
        }
    }
}
