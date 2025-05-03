using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public AdminController(UserManager<IdentityUser> User , RoleManager<IdentityRole> Role)
        {
            _usermanager = User;
            _rolemanager = Role;
        }
        [HttpGet]
        public async Task<IActionResult> UsersList()
        {
            var users = _usermanager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> UserRolesList()
        {
            var Users = _usermanager.Users.ToList();
            var UserRolesVm = new List<UserRolesVm>();
            foreach (var user in Users)
            {
                var Vm = new UserRolesVm();
                Vm.UserId = user.Id;
                Vm.UserName = user.UserName;
                Vm.Roles = await GetUserRoles(user);
                UserRolesVm.Add(Vm);
            }
            ViewBag.AllRoles=_rolemanager.Roles.Select(X  => X.Name).ToList();  
            return View(UserRolesVm);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRoles (string UserId, List<string> roles)
        {
            var user = await _usermanager.FindByIdAsync(UserId);
            if(User ==null)
            {
                return NotFound();
            }
            var CurrentRoles = await GetUserRoles(user);

            var rolesToRemove = CurrentRoles.Except(roles).ToList();
			var rolesToAdd = roles.Except(CurrentRoles).ToList();
            await _usermanager.AddToRolesAsync(user, rolesToAdd);
			await _usermanager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("UserRolesList");

		}
		private async Task<List<string>?> GetUserRoles(IdentityUser User)
        {
            var roles =  await _usermanager.GetRolesAsync(User);
            var rolesList = new List<string>(roles);
            return rolesList;
        }
    }
}
