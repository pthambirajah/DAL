using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult LoginError(string message)
        {
            ErrorViewModel notFound = new ErrorViewModel();
            notFound.message = message;
            return View(notFound);
        }

        public IActionResult OrderCancelError(string message)
        {
            ErrorViewModel cannotCancel = new ErrorViewModel();

            cannotCancel.message = message;
            return View(cannotCancel);
        }

        public IActionResult CartError(string message)
        {
            ErrorViewModel cartempty = new ErrorViewModel();

            cartempty.message = message;
            return View(cartempty);
        }

        public IActionResult NoOrderError(string message)
        {
            ErrorViewModel listempty = new ErrorViewModel();

            listempty.message = message;
            return View(listempty);
        }
    }
}