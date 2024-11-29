using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Errors/404")]
        public IActionResult Error404()
        {
            return View("404");
        }

        [Route("Errors/500")]
        public IActionResult Error500()
        {
            return View("500");
        }
    }
}
