using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class ShoppingCartController : Controller
    {

        private IConfiguration Configuration { get; }
        public ShoppingCartController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public void AddToCart(int id, int quantity)
        {
            DishesManager dManager = new DishesManager(Configuration);
            
            // Retrieve the product from the database.           
            Dishes disheToAdd = dManager.GetDishe(id);

            var cart = new List<Dishes_order>();
            cart.Add(new Dishes_order()
            {
                idDishes = id,
                quantity = quantity
            });

           





        }
    }
}