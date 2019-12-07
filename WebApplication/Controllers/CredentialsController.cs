using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DTO;
using BLL;

namespace WebApplication.Controllers
{
    public class CredentialsController : Controller
    {
        private IConfiguration Configuration { get; }


        public CredentialsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*
        [HttpPost]
        public ActionResult Autherize(Credentials credModel)
        {
            string usernameC;
            string passwordC;

            var customerDbManager = new CredentialsManager(Configuration);
            int idCustomerTryingToConnect = customerDbManager.GetIdCredentials(usernameC);

            //En fonction de l'id du customer
            while (passwordC != customerDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
            {

                Console.WriteLine(passwordC);
                Console.WriteLine("Connection denied. Try again");

                Console.WriteLine("Username");
                usernameC = Console.ReadLine();

                Console.WriteLine("Password");
                passwordC = Console.ReadLine();

                idCustomerTryingToConnect = customerDbManager.GetIdCredentials(usernameC);
            }

            Console.WriteLine("Connection successful");

        }


        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
    */


}
}