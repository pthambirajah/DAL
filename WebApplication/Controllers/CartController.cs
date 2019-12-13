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

            int entriesleft=0;

            /*if (idAvailability <= 15)
                entriesleft = 15 - idAvailability;
            else if (idAvailability <= 30)
                entriesleft = 30 - idAvailability;
            else if (idAvailability <= 45)
                entriesleft = 45 - idAvailability;
*/

            //if (entriesleft >= 2)
            if (idAvailability % 15 < 14)
            {
                //additioning the counter of the cur. time + cur. time + 15 + cur. time + 30
                int totalCounter = aManager.GetCounter(idAvailability) + aManager.GetCounter(idAvailability + 1) + aManager.GetCounter(idAvailability + 2);

                if (totalCounter >= 5)
                    //Make deliveryBoy unavailable at the choosen time
                    aManager.UpdateAvailability(idAvailability);

                for (int i = idAvailability; i <= idAvailability + 2; i++)
                    //increment counter
                    aManager.IncrementCounter(i);
            }
            else if (idAvailability % 15 == 14)
            //if (entriesleft == 14)
            {
                int totalCounter = aManager.GetCounter(idAvailability) + aManager.GetCounter(idAvailability + 1);

                if (totalCounter >= 5)
                    //Make deliveryBoy unavailable at the choosen time
                    aManager.UpdateAvailability(idAvailability);

                for (int i = idAvailability; i <= idAvailability + 1; i++)
                    //increment counter
                    aManager.IncrementCounter(i);
            }
            else if (idAvailability % 15 == 0)
            { 
               // if (entriesleft == 0) {
                int totalCounter = aManager.GetCounter(idAvailability);

                if (totalCounter >= 5)
                    //Make deliveryBoy unavailable at the choosen time
                    aManager.UpdateAvailability(idAvailability);
                
                aManager.IncrementCounter(idAvailability);
            }
        
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

            cart = null;
            //Clean up cart
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            HttpContext.Session.SetInt32("TotalAmount", 0);
            return View();
        }
    }
}