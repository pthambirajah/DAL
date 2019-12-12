﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}