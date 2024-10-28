using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web.Controllers
{
	public class RecipeController : Controller
	{
		private readonly ILogger<RecipeController> logger;
		private readonly UserManager<ApplicationUser> user;
        private readonly FitnessDBContext context;

        public RecipeController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
		{
            logger = _logger;
			user = _user;
            context = _context;
        }

		public IActionResult Index()
        {
            var model = context.Recipes. /*Where(r=>r.UserID==null)*/Select(r => new RecipesIndexView
            {
                ImageUrl = r.ImageUrl,
                Name = r.Name,
                UserID = r.UserID,
            }).ToList();

            return View(model);
		}

        public IActionResult Add()
        {
            return View();
        }
    }
}
