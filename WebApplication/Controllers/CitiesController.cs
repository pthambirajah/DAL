using System.Collections.Generic;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CitiesController : Controller
    {
        private IConfiguration Configuration { get; }
        public CitiesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Display cities in our Network
        public ActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            CitiesManager cManager = new CitiesManager(Configuration);
            return View(cManager.GetCities());
        }

        //Display restaurants of our network in the selected city
        public ActionResult Restaurants(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            RestaurantManager rManager = new RestaurantManager(Configuration);
            return View(rManager.GetRestaurantsOfCity(id));
        }

        //Display dishes served by the selected restaurant
        public ActionResult Dishes(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            DishesManager dManager = new DishesManager(Configuration);
            return View(dManager.GetDishesOfRestaurant(id));
        }

        //Allows customer to add a dish to his cart
        public ActionResult AddToCart(int id)
        {
            //We retrieve the dishe's price
            DishesManager dManager = new DishesManager(Configuration);
            Dishes dishe = new Dishes();
            int price = dManager.GetDishePrice(id);

            //We add the price to the total amount, we initiate the session value if it is the first dish of the cart.
            if (HttpContext.Session.GetInt32("TotalAmount") != null) {

                HttpContext.Session.SetInt32("TotalAmount", (price + (int)HttpContext.Session.GetInt32("TotalAmount")));
            }
            else
            {
                HttpContext.Session.SetInt32("TotalAmount", price );
            }
            //So if it is the first dish to be added we create a list of item(Dishe+quantity) in the session
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Dishe = dManager.GetDishe(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {   /*Else if the list is already created we get it and check if the dish is already in the list.
                    If yes we increment the quantity, else we add the dish as a new item.
                 */
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = DoesExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Dishe = dManager.GetDishe(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            //Redirect to the cart
            return RedirectToAction("Index", "Cart");
        }

        //Go through the list of item and try to match the id with an existing dish
        private int DoesExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Dishe.idDishes.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        
    }
}
