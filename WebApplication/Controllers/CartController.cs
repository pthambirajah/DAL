using System;
using System.Collections.Generic;
using System.Linq;
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
        //Display the actual cart and total amount
        public IActionResult Index()
        {
            ViewBag.totalAmount = HttpContext.Session.GetInt32("TotalAmount");
            ViewBag.username = HttpContext.Session.GetString("username");
          
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                return View(cart);
            }
            return RedirectToAction("CartError", "Error", new { message = "You have nothing in the cart. Feel free to add something !" });
        }
        
        //Allows a customer to delete a dishe from the cart. If there is multiple times the same dish, quantity will be decremented.
        public IActionResult DeleteItem(int idDish)
        {
            DishesManager dManager = new DishesManager(Configuration);
            int price = dManager.GetDishePrice(idDish);
            HttpContext.Session.SetInt32("TotalAmount", (int) HttpContext.Session.GetInt32("TotalAmount") - price);
           
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            var itemToRemove = cart.Single(d => d.Dishe.idDishes == idDish);
            //In case of the element the customer wants to delete is the last one, we empty the session.
            if (cart.Count == 1)
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", null);
            }
            //If the item has more than 1 quantity, we just decrement it but do not delete the entire
            else if (itemToRemove.Quantity>1)
            {
                cart.Remove(itemToRemove);
                itemToRemove.Quantity--;
                cart.Add(itemToRemove);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                cart.Remove(itemToRemove);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        //Display available delivery time for a staff 
        //But the user must be logged in
        public IActionResult SelectTime()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            if (HttpContext.Session.GetInt32("id")== null) {
                return RedirectToAction("loginError", "Error", new { message = "Unfortunately it seems like you are not logged in. Please log in." });
            }
            int restaurant = 0;
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            //We reuse the id of the restaurant to find our its location and suggest the correct staff's availability
            foreach (Item dish in cart)
            {
                restaurant = dish.Dishe.idRestaurant;
            }
            AvailibilityManager aManager = new AvailibilityManager(Configuration);
            return View(aManager.GetAvailabilitiesByRestaurant(restaurant));
        }

        //Insert the cart into the database
        public IActionResult ProceedCheckout(int idAvailability, int idStaff, TimeSpan choosenTime)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            ViewBag.totalAmount = HttpContext.Session.GetInt32("TotalAmount");
            int idCredentials = (int)HttpContext.Session.GetInt32("id");
            CustomerManager cManger = new CustomerManager(Configuration);
            int idCustomer = cManger.GetCustomerIDByCredentials(idCredentials);
            AvailibilityManager aManager = new AvailibilityManager(Configuration);

            if (idAvailability % 15 < 14 && idAvailability % 15 >= 1)
            {
                //additioning the counter of the cur. time + cur. time + 15 + cur. time + 30
                int totalCounter = aManager.GetCounter(idAvailability) + aManager.GetCounter(idAvailability + 1) + aManager.GetCounter(idAvailability + 2);

                if (totalCounter >=4)
                    //Make deliveryBoy unavailable at the choosen time, 0 means unavailable
                    aManager.UpdateAvailability(idAvailability, 0);

                for (int i = idAvailability; i <= idAvailability + 2; i++)
                    //increment counter
                    aManager.IncrementCounter(i);
            }
            else if (idAvailability % 15 == 14)
  
            {
                int totalCounter = aManager.GetCounter(idAvailability) + aManager.GetCounter(idAvailability + 1);

                if (totalCounter >= 4)
                    //Make deliveryBoy unavailable at the choosen time
                    aManager.UpdateAvailability(idAvailability, 0);

                for (int i = idAvailability; i <= idAvailability + 1; i++)
                    //increment counter
                    aManager.IncrementCounter(i);
            }
            else if (idAvailability % 15 == 0)
            { 
                int totalCounter = aManager.GetCounter(idAvailability);

                if (totalCounter >= 4)
                    //Make deliveryBoy unavailable at the choosen time
                    aManager.UpdateAvailability(idAvailability, 0);
                
                aManager.IncrementCounter(idAvailability);
            }
        
            //First we add the delivery
            DeliveryManager dManager = new DeliveryManager(Configuration);
            dManager.AddDelivery(choosenTime, idStaff);
            int lastDelivery = dManager.GetLastId();

            OrderManager oManager = new OrderManager(Configuration);
            //Then we create the order
            oManager.AddOrder(idCustomer, lastDelivery);
            int lastOrder = oManager.GetLastId();
            //Finaly we link each dish to the order in the dish_order table
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Dishes_orderManager doManager = new Dishes_orderManager(Configuration);

            foreach (Item dish in cart)
            {
                doManager.AddDishes_order(dish.Dishe.idDishes, lastOrder, dish.Quantity);
            }
            //This way we respect every foreign key and we do not generate errors.
            cart = null;
            //Clean up cart
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            HttpContext.Session.SetInt32("TotalAmount", 0);
            return View();
        }
    }
}