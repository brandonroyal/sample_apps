using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class MetaDataController : ApiController
    {
        [HttpGet]
        public MetaData Index()
        {
            var model = new MetaData();
            model.Hostname = Dns.GetHostName();
            return model;
        }
    }
}
