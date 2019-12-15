using System;
using System.Collections.Generic;
using BLL;
using DTO;
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
            List<deliveryItem> OrderToDeliver = dManager.GetDishes_orderByStaff(id);
            if (OrderToDeliver != null)
            {
                return View(OrderToDeliver);
            }
            return RedirectToAction("NoOrderError", "Error", new { message ="You don't have any orders, enjoy while it lasts! :-)" });
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

        public IActionResult CheckBeforeCancel(int idOrder, TimeSpan deliveryTime)
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

        public ActionResult CancelOrder(Customer customerModel)
        {
            var customerDbManager = new CustomerManager(Configuration);
            int idCustomer = (int)HttpContext.Session.GetInt32("idCustomer");
            Customer customer = customerDbManager.GetFirstnameLastname(idCustomer);
            //We make our strings lower case so we don't care whether the customer use capital case or not.
            string firstnameC = customerModel.FirstName.ToLower();
            string lastnameC = customerModel.LastName.ToLower();

            if (firstnameC.Equals(customer.FirstName.ToLower()) && lastnameC.Equals(customer.LastName.ToLower()))
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