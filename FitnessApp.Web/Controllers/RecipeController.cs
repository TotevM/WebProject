using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
	public class RecipeController : Controller
	{
		private readonly ILogger<RecipeController> logger;
		private readonly UserManager<ApplicationUser> user;

		public RecipeController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user)
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
