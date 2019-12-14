using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult reset()
        {
            AvailibilityManager aManager = new AvailibilityManager(Configuration);
            aManager.ResetAvailability();
            return RedirectToAction("Index", "Home");
        }
    }
}