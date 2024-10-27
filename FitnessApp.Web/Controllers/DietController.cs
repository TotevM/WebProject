using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
	public class DietController : Controller
	{
		private readonly ILogger<DietController> logger;
		private readonly UserManager<ApplicationUser> user;

		public DietController(ILogger<DietController> _logger, UserManager<ApplicationUser> _user)
		{
			logger = _logger;
			user = _user;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
