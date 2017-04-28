using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IBackendMetadataRepository _repo;
        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeViewModel();
            model.Identity = System.Web.HttpContext.Current.User.Identity;
            model.Hostname = System.Net.Dns.GetHostName();
            model.BackendEnabled = !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("API_HOSTNAME"));
            if (model.BackendEnabled)
            {
                model.BackendMetaData = _repo.GetMetaData();
            }
            return View(model);
        }

        public HomeController() : this(new BackendMetadataRepository())
        { }

        public HomeController(IBackendMetadataRepository repo)
        {
            _repo = repo;
        }
    }
}