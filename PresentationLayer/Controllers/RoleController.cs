using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ActionRequests;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Roles = _roleManager.Roles.ToList();
            return  View(Roles);
        }

		[HttpGet]
		public async Task<IActionResult> CreateRole()
		{
		return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleActionRequest request )
		{
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = request.RoleName;
                IdentityResult result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return View();
		}
	}
}
