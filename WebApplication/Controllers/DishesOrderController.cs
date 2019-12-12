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
    public class DishesOrderController : Controller
    {

        private IConfiguration Configuration { get; }
        public DishesOrderController (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(int idC)
        {
            int id = (int) HttpContext.Session.GetInt32("idStaff");
            ViewBag.username = HttpContext.Session.GetString("username");
            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);

            if (idC == 1)
            {
                dManager.UpdateOrderStatus(id);

            }
            return View(dManager.GetDishes_orderByStaff(id));
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus ()
        {
            int id = (int)HttpContext.Session.GetInt32("idStaff");
            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
            dManager.UpdateOrderStatus(id);

            //a loop coming back to your list with param id
            return RedirectToAction("Index", "DishesOrder"); 

        }
    }
}