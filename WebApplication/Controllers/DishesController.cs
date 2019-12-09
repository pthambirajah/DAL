﻿using System;
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
    public class DishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public DishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            DishesManager dManager = new DishesManager(Configuration);
            return View(dManager.GetDishes());
        }

        public ActionResult AddToCart(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
           // HttpContext.Session.Set("cart", id);
            DishesManager dManager = new DishesManager(Configuration);
            return View(dManager.GetDishes());
        }

        
    }
}