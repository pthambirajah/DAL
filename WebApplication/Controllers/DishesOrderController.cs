using System;
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

       
        public IActionResult Index()
        {
            int id = (int) HttpContext.Session.GetInt32("idStaff");
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
            return View(dManager.GetDishes_orderByStaff(id));
        }
        
        public IActionResult UpdateOrderStatus (int idOrder)
        {
            int id = (int)HttpContext.Session.GetInt32("idStaff");

            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
            dManager.UpdateOrderStatus(idOrder);

            return View(dManager.GetDishes_orderByStaff(id));
        }

        public IActionResult customerOrders()
        {
            int id = (int)HttpContext.Session.GetInt32("idCustomer");
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
            return View(dManager.GetDishes_orderByCustomer(id));
        }

       /* public IActionResult cancel(int idOrder, TimeSpan deliveryTime)
        {
            TimeSpan limit = DateTime.Now.TimeOfDay;
            TimeSpan variation = TimeSpan.FromHours(3);
            limit = limit.Add(variation);
            if (TimeSpan.Compare(deliveryTime, limit) > 0)
            {
                Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
                dManager.UpdateOrderStatusToCancel(idOrder);
            }
            else
            {
                return RedirectToAction("OrderCancelError", "Error", new { message = "Unfortunately you cannot cancel this order anymore. You should have cancelled 3 hours before the delivery time. Sorry :(" });
            }
            return RedirectToAction("customerOrders");
        }*/
    }
}