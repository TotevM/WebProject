using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class WorkoutController: Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<ApplicationUser> user;

        public WorkoutController(ILogger<HomeController> _logger, UserManager<ApplicationUser> _user)
        {
            logger = _logger;
            user = _user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddWorkoutForm()
        {
            return View();
        }
    }
}
