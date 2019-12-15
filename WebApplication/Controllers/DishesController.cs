using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class DishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public DishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Index()
        {
            ViewBag.userType = HttpContext.Session.GetInt32("userType");
            ViewBag.username = HttpContext.Session.GetString("username");
            DishesManager dManager = new DishesManager(Configuration);

            return View(dManager.GetDishes());
        } 
    }
}