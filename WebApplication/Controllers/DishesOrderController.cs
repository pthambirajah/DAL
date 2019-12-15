using System;
using System.Collections.Generic;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.Helpers;

namespace WebApplication.Controllers
{
    public class DishesOrderController : Controller
    {

        private IConfiguration Configuration { get; }
        public DishesOrderController (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Display to the delivery employee all the deliveries to do of the day
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
        //Used by the delivery employee to archive a delivery once it is done.
        public IActionResult UpdateOrderStatus (int idOrder)
        {
            int id = (int)HttpContext.Session.GetInt32("idStaff");

            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
            dManager.UpdateOrderStatus(idOrder);

            return RedirectToAction("Index");
        }

        //Display all the orders and their status that a customer have ever made
        public IActionResult CustomerOrders()
        {
            int id = (int)HttpContext.Session.GetInt32("idCustomer");
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
            return View(dManager.GetDishes_orderByCustomer(id));
        }

        //Little checkup before cancelling an order, there must be 3 hours remaining before the specified delivery time for a cancellation.
        public IActionResult CheckBeforeCancel(int idOrder, TimeSpan deliveryTime, int idStaff)
        {
            HttpContext.Session.SetInt32("idOrder", idOrder);
            TimeSpan limit = DateTime.Now.TimeOfDay;
            TimeSpan variation = TimeSpan.FromHours(3);
            limit = limit.Add(variation);
            if (TimeSpan.Compare(deliveryTime, limit) > 0)
            {
                //We store the idStaff who will "lose" a delivery
                HttpContext.Session.SetInt32("idStaffToDecrement", idStaff);
                SessionHelper.SetObjectAsJson(HttpContext.Session,"deliveryTimeToCancel", deliveryTime);
                return View();
            }
            else
            {
                //Through an error if the cancellation is not possible
                return RedirectToAction("OrderCancelError", "Error", new { message = "Unfortunately you cannot cancel this order anymore. You should have cancelled 3 hours before the delivery time. Sorry :(" });
            }
        }

        //Cancel an order and decrement a counter so the delivery employee may be available again
        //The user must enter his firstname and lastaname correctly to make all this happening.
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
                int idStaffToDecrement = (int)HttpContext.Session.GetInt32("idStaffToDecrement");
                TimeSpan deliveryTimeToCancel = SessionHelper.GetObjectFromJson<TimeSpan>(HttpContext.Session, "deliveryTimeToCancel");

                Dishes_orderManager dManager = new Dishes_orderManager(Configuration);
                dManager.UpdateOrderStatusToCancel(idOrder);

                AvailibilityManager aManager = new AvailibilityManager(Configuration);
                aManager.DecrementCounter(idStaffToDecrement);

                Availability availabilityStatus = aManager.IsAvailable(idStaffToDecrement, deliveryTimeToCancel);
                if (!availabilityStatus.isAvailable){
                    aManager.UpdateAvailability(availabilityStatus.idAvailability, 1);
                }
                return RedirectToAction("customerOrders", "DishesOrder");
            }
            else
            {
                //If the user fails in entering a correct firstname and lastname the cancellation do not happen
                return RedirectToAction("OrderCancelError", "Error", new { message = "Unfortunately your firstname or lastname did not match our records. Please try again." });
            }
        }
    }
}