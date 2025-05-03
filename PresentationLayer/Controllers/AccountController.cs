using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ActionRequests;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IUserServices userServices , UserManager<IdentityUser> userManager)
        {
            _userServices = userServices;
            _userManager = userManager;
        }

        /////////// LOGIN //////////////
        [HttpGet]
        public IActionResult Login([FromQuery] string? ReturnUrl)
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserActionRequest request, string? ReturnUrl)
        {

            if (ModelState.IsValid)
            {

                var User = await _userServices.FindUserByUserName(request.Name);
             


                // If  User exists
                if (User != null)
                {
                    var isPasswordValid = await _userServices.CheckPassword(User, request.Password);
                    if (isPasswordValid)
                    {
                        await _userServices.Signin(User, request.RememberMe);

                        bool IsInCustomerRole = await _userManager.IsInRoleAsync(User, "Customer");
                        if (IsInCustomerRole)
                        {
                        return RedirectToAction("Index", "Home");
                        }
                        var IsInAdminRole = await _userManager.IsInRoleAsync(User, "Admin");
                        if (IsInAdminRole)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
                // If user doesn't exist
                ModelState.AddModelError("Invalid Credentials", "Invalid username or password");
            }
            return View();
        }

        /////////////// REGISTER (SIGN UP) ///////////////
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserActionRequest NewAccount)
        {
            if (ModelState.IsValid)
            {
                var UserDto = new CreateUserDto
                {
                    UserName = NewAccount.UserName,
                    Password = NewAccount.Password,
                    ConfirmPassword = NewAccount.ConfirmPassword,
                };
                // Create New Account 
                IdentityResult result = await _userServices.RegisterUser(UserDto);
                if (result.Succeeded)
                {    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View(NewAccount);
        }

         /////////////// LOGOUT ///////////////
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
           await _userServices.Signout();
            return RedirectToAction("Index","Home");
        }
    }
}
