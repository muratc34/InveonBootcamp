using Domain.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Admin") || (currentUser != null && currentUser.Id.ToString() == id))
            {
                return View(currentUser);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Admin") || (currentUser != null && currentUser.Id.ToString() == id))
            {
                currentUser.UserName = model.UserName;
                currentUser.Email = model.Email;
                currentUser.FirstName = model.FirstName;
                currentUser.LastName = model.LastName;

                var result = await _userManager.UpdateAsync(currentUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Details", "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAction(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Admin") || (currentUser != null && currentUser.Id.ToString() == id))
            {
                var result = await _userManager.DeleteAsync(currentUser);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Details", new { id });
        }
    }
}
