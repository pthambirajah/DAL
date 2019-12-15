using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class AvailabilityController : Controller
    {
        private IConfiguration Configuration { get; }
        public AvailabilityController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Allows the administrator to reset availability of every delivery employee.
        public IActionResult Reset()
        {
            AvailibilityManager aManager = new AvailibilityManager(Configuration);
            aManager.ResetAvailability();
            return RedirectToAction("Index", "Home");
        }
    }
}