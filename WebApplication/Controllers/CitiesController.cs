using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class CitiesController : Controller
    {

        private IConfiguration Configuration { get; }
        public CitiesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Index()
        {
            CitiesManager cManager = new CitiesManager(Configuration);
            return View(cManager.GetCities());
        }

    }
}