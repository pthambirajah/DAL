using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {
        private IConfiguration Configuration { get; }
        public CartController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.totalAmount = HttpContext.Session.GetInt32("TotalAmount");

            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View(cart);
        }

        public IActionResult SelectTime()
        {
            int restaurant = 0;
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            foreach (Item dish in cart)
            {
                restaurant = dish.Dishe.idRestaurant;
            }
            AvailibilityManager aManager = new AvailibilityManager(Configuration);
            return View(aManager.GetAvailabilitiesByRestaurant(restaurant));
        }

        
        public IActionResult ProceedCheckout(int idAvailability, int idStaff, TimeSpan choosenTime)
        {
            ViewBag.totalAmount = HttpContext.Session.GetInt32("TotalAmount");
            int idCredentials = (int)HttpContext.Session.GetInt32("id");
            CustomerManager cManger = new CustomerManager(Configuration);
            int idCustomer = cManger.GetCustomerIDByCredentials(idCredentials);
            AvailibilityManager aManager = new AvailibilityManager(Configuration);

            //Make deliveryBoy unavailable at the choosen time
            aManager.UpdateAvailability(idAvailability);

            DeliveryManager dManager = new DeliveryManager(Configuration);
            dManager.AddDelivery(choosenTime, idStaff);
            int lastDelivery = dManager.GetLastId();

            OrderManager oManager = new OrderManager(Configuration);

            oManager.AddOrder(idCustomer, lastDelivery);
            int lastOrder = oManager.GetLastId();

            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Dishes_orderManager doManager = new Dishes_orderManager(Configuration);

            foreach (Item dish in cart)
            {
                doManager.AddDishes_order(dish.Dishe.idDishes, lastOrder, dish.Quantity);
            }

            return View();
        }
    }
}