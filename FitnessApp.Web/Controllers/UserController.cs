//using FitnessApp.Data.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;

//namespace FitnessApp.Web.Controllers
//{
//    public class UserController : Controller
//    {
//        private readonly UserManager<ApplicationUser> userManager;

//        public UserController(UserManager<ApplicationUser> userManager)
//        {
//            this.userManager = userManager;
//        }
//        [HttpPost]
//        public async Task<IActionResult> OnGetAsync()
//        {
//            var user = await userManager.GetUserAsync(User);

//            if (user == null)
//            {
//                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
//            }

//            ImagePath = user.ImagePath;

//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            var user = await _userManager.GetUserAsync(User);

//            if (user == null)
//            {
//                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
//            }

//            if (ProfilePicture != null)
//            {
//                // Ensure directory exists
//                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "profiles");
//                Directory.CreateDirectory(uploadsFolder);

//                // Save the file with a unique name
//                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProfilePicture.FileName);
//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    await ProfilePicture.CopyToAsync(fileStream);
//                }

//                // Update user profile image path
//                user.ImagePath = $"/images/profiles/{uniqueFileName}";
//                await _userManager.UpdateAsync(user);
//            }

//            StatusMessage = "Your profile has been updated";
//            return RedirectToPage();
//        }
//    }
//}
