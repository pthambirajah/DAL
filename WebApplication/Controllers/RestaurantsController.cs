using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class RestaurantsController : Controller
    {

        private IConfiguration Configuration { get; }
        public RestaurantsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            RestaurantManager rManager = new RestaurantManager(Configuration);
            return View(rManager.GetRestaurants());
        }

        
    }
}