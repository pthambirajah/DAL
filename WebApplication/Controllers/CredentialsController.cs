using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DTO;
using BLL;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class CredentialsController : Controller
    {
        private IConfiguration Configuration { get; }


        public CredentialsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(Credentials credModel)
        {
            string usernameC = credModel.username;
            string passwordC = credModel.password;

            var credentialsDbManager = new CredentialsManager(Configuration);
            int idCustomerTryingToConnect = credentialsDbManager.GetIdCredentials(usernameC);

            //En fonction de l'id du customer
            if (passwordC == credentialsDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
            {
                HttpContext.Session.SetString("username", usernameC);
                HttpContext.Session.SetInt32("id", idCustomerTryingToConnect);
                if (credentialsDbManager.isAdmin(usernameC))
                {
                    return RedirectToAction("Index", "DishesOrder");
                }

               else if (credentialsDbManager.isStaff(usernameC))
                {

                    StaffManager sManager = new StaffManager(Configuration);
                    int idStaff = sManager.GetStaffId(idCustomerTryingToConnect);
                    HttpContext.Session.SetInt32("idStaff", idStaff);
                    return RedirectToAction("Index", "DishesOrder");

                }
                CustomerManager cManager = new CustomerManager(Configuration);
                HttpContext.Session.SetInt32("idCustomer", cManager.GetCustomerIDByCredentials(idCustomerTryingToConnect));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Cities");
            }
        }

    }

    


}
