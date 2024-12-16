using Domain.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers;
[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string roleName)
    {
        if (!ModelState.IsValid)
        {
            return View(roleName);
        }
        var result = await _roleManager.CreateAsync(new ApplicationRole(roleName));
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Role");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(roleName);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        var model = new RoleEditViewModel
        {
            Id = role.Id.ToString(),
            RoleName = role.Name
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RoleEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = model.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        var result = await _roleManager.DeleteAsync(role);
        if (result.Succeeded)
        {
            return RedirectToAction(nameof(Index));
        }
        ModelState.AddModelError("", "An error occurred while deleting the role.");
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> AssignRole(string id)
    {
        var currentUser = (await _userManager.FindByIdAsync(id))!;
        ViewBag.userId = id;
        var roles = await _roleManager.Roles.ToListAsync();
        var userRoles = await _userManager.GetRolesAsync(currentUser);
        var roleViewModelList = new List<AssignRoleToUserViewModel>();

        foreach (var role in roles)
        {

            var assignRoleToUserViewModel = new AssignRoleToUserViewModel() { Id = role.Id.ToString(), Name = role.Name! };

            if (userRoles.Contains(role.Name!))
            {
                assignRoleToUserViewModel.Exist = true;
            }

            roleViewModelList.Add(assignRoleToUserViewModel);
        }

        return View(roleViewModelList);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(string userId, List<AssignRoleToUserViewModel> requestList)
    {

        var userToAssignRoles = (await _userManager.FindByIdAsync(userId))!;

        foreach (var role in requestList)
        {

            if (role.Exist)
            {
                await _userManager.AddToRoleAsync(userToAssignRoles, role.Name);

            }
            else
            {
                await _userManager.RemoveFromRoleAsync(userToAssignRoles, role.Name);
            }

        }

        return RedirectToAction("Index", "User");
    }
}
