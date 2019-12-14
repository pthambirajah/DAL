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
        public IActionResult loginError()
        {
            ErrorViewModel notFound = new ErrorViewModel();
            notFound.message = "Unfortunately your username or password did not match our records. Please try again.";
            return View(notFound);
        }
    }
}