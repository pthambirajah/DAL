using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
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
            ViewBag.username = HttpContext.Session.GetString("username");
            CitiesManager cManager = new CitiesManager(Configuration);
            return View(cManager.GetCities());
        }

        public ActionResult Restaurants(int id)
        {
            RestaurantManager rManager = new RestaurantManager(Configuration);
            return View(rManager.GetRestaurantsOfCity(id));
        }

        public ActionResult Dishes(int id)
        {
            DishesManager dManager = new DishesManager(Configuration);
            return View(dManager.GetDishesOfRestaurant(id));
        }

    }
}