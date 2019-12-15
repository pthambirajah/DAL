using System;
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
    public class CancelController : Controller
    {
        private IConfiguration Configuration { get; }
        public CancelController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customerModel)
        {
            var customerDbManager = new CustomerManager(Configuration);
            int idCustomer = (int)HttpContext.Session.GetInt32("id");
            Customer customer = customerDbManager.GetFirstnameLastname(idCustomer);
            string firstnameC = customerModel.FirstName;
            string lastnameC = customerModel.LastName;

            if (firstnameC.Equals(customer.FirstName) && lastnameC.Equals(customer.LastName))
            {


                return RedirectToAction("Index", "Home");
            }
            else 
            {
                return RedirectToAction("loginError", "Error", new { message = "Unfortunately your username or password did not match our records. Please try again." });
            }
        }
    }
}