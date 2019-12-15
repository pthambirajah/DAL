using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult loginError(string message)
        {
            ErrorViewModel notFound = new ErrorViewModel();
            //notFound.message = "Unfortunately your username or password did not match our records. Please try again.";
            notFound.message = message;
            return View(notFound);
        }

        public IActionResult orderCancelError(string message)
        {
            ErrorViewModel cannotCancel = new ErrorViewModel();

            cannotCancel.message = message;
            return View(cannotCancel);
        }




    }
}