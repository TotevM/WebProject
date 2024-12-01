using FitnessApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Areas.Admin.Controllers
{
    [Area(AdminRole)]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
