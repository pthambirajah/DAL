﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        List<int> cart;

        private IConfiguration Configuration { get; }
        public CitiesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            CitiesManager cManager = new CitiesManager(Configuration);
            return View(cManager.GetCities());
        }

        public ActionResult Restaurants(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            RestaurantManager rManager = new RestaurantManager(Configuration);
            return View(rManager.GetRestaurantsOfCity(id));
        }

        public ActionResult Dishes(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            DishesManager dManager = new DishesManager(Configuration);
            return View(dManager.GetDishesOfRestaurant(id));
        }

        public ActionResult AddToCart(int id)
        {
            
            DishesManager dManager = new DishesManager(Configuration);
            Dishes dishe = new Dishes();
            int price = dManager.GetDishePrice(id);

            if (HttpContext.Session.GetInt32("TotalAmount") != null) {

                HttpContext.Session.SetInt32("TotalAmount", (price + (int)HttpContext.Session.GetInt32("TotalAmount")));
            }
            else
            {
                HttpContext.Session.SetInt32("TotalAmount", price );
            }
            
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Dishe = dManager.GetDishe(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
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
            return RedirectToAction("Index");
        }

            private int isExist(int id)
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