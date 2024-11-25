using Microsoft.AspNetCore.Mvc;

using FitnessApp.Infrastructure.Extensions;
using FitnessApp.Services.ServiceContracts;
namespace FitnessApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
