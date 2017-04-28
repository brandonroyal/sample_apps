using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Api.Models;

namespace Web.Models
{
    public class HomeViewModel
    {
        public IIdentity Identity { get; set; }
        public String Hostname { get; set; }
        public bool BackendEnabled { get; set; }
        public MetaData BackendMetaData { get; set; }
    }
}