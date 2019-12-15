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
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(Credentials credModel)
        {
            string usernameC = credModel.username;
            string passwordC = credModel.password;

            var credentialsDbManager = new CredentialsManager(Configuration);
            int idCustomerTryingToConnect = credentialsDbManager.GetIdCredentials(usernameC);
            int userStatus = credentialsDbManager.GetStatus(usernameC);
            //En fonction de l'id du customer
            if (passwordC == credentialsDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
            {
                HttpContext.Session.SetString("username", usernameC);
                HttpContext.Session.SetInt32("id", idCustomerTryingToConnect);
                HttpContext.Session.SetInt32("userType", userStatus);
                if (userStatus == 2)
                {
                    return RedirectToAction("Index", "Home");
                }

                else if (userStatus == 1)
                {
                    StaffManager sManager = new StaffManager(Configuration);
                    int idStaff = sManager.GetStaffId(idCustomerTryingToConnect);
                    HttpContext.Session.SetInt32("idStaff", idStaff);
                    return RedirectToAction("Index", "DishesOrder");
                }
                else if (userStatus == 0)
                {
                    CustomerManager cManager = new CustomerManager(Configuration);
                    HttpContext.Session.SetInt32("idCustomer", cManager.GetCustomerIDByCredentials(idCustomerTryingToConnect));
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("LoginError", "Error", new { message = "Your account is not correctly initialized. Please contact our support : support@vdeat.ch or connect with another account." });
            }
            else
            {
                return RedirectToAction("LoginError", "Error", new { message = "Unfortunately your username or password did not match our records. Please try again." });
            }
        }
    }
}
