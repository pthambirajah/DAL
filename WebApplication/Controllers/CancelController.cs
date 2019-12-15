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
    public class CancelController : Controller
    {
        private IConfiguration Configuration { get; }
        public CancelController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(int idOrder, TimeSpan deliveryTime)
        {
            HttpContext.Session.SetInt32("idOrder", idOrder);
            TimeSpan limit = DateTime.Now.TimeOfDay;
            TimeSpan variation = TimeSpan.FromHours(3);
            limit = limit.Add(variation);
            if (TimeSpan.Compare(deliveryTime, limit) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("OrderCancelError", "Error", new { message = "Unfortunately you cannot cancel this order anymore. You should have cancelled 3 hours before the delivery time. Sorry :(" });
            }
            
        }

        [HttpPost]
        public ActionResult Index(Customer customerModel)
        {
            var customerDbManager = new CustomerManager(Configuration);
            int idCustomer = (int)HttpContext.Session.GetInt32("idCustomer");
            Customer customer = customerDbManager.GetFirstnameLastname(idCustomer);
            string firstnameC = customerModel.FirstName;
            string lastnameC = customerModel.LastName;

            if (firstnameC.Equals(customer.FirstName) && lastnameC.Equals(customer.LastName))
            {
                int idOrder = (int)HttpContext.Session.GetInt32("idOrder");
                Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
                dManager.UpdateOrderStatusToCancel(idOrder);
                return RedirectToAction("customerOrders", "DishesOrder");
            }
            else 
            {
                return RedirectToAction("OrderCancelError", "Error", new { message = "Unfortunately your firstname or lastname did not match our records. Please try again." });
            }
        }
    }
}