using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Models.credentials userModel)
        {
            using (GharbiThambirajahProject2Entities1 db = new GharbiThambirajahProject2Entities1())
            {
                var userDetails = db.credentials.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.idCredentials;
                    Session["userName"] = userDetails.idCredentials;
                    return RedirectToAction("Index", "Home");
                }
            }
        }C:\Users\alexg\source\repos\DAL\DAL\IavailabilityDB.cs

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
