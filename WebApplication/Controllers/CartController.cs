using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.totalAmount = HttpContext.Session.GetInt32("TotalAmount");
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View(cart);
        }
        public IActionResult ConfirmOrder()
        {
            ViewBag.totalAmount = HttpContext.Session.GetInt32("TotalAmount");
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View(cart);
        }
    }
}