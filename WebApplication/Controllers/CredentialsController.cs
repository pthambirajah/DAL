﻿using System;
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
            //while (passwordC != credentialsDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
            if (passwordC == credentialsDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
            {
                HttpContext.Session.SetString("username", usernameC);
                if (credentialsDbManager.isAdmin(usernameC))
                {
                    return RedirectToAction("Index", "DishesOrder", new { id = 2 });
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Cities");
            }
        }


       /* public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }*/

    }

    


}