using System.Diagnostics;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.Data.Models.Models;
using FitnessApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<ApplicationUser> user;
        private readonly FitnessDBContext context;

        public HomeController(ILogger<HomeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
        {
            logger = _logger;
            user = _user;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
