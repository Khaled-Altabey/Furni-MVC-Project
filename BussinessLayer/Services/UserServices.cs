using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using BussinessLayer.Mapping;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManger;

        public UserServices(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signinManger)
        {
            _userManager = userManager;
            _signinManger = signinManger;
        }
        /////////// CHECK PASSWORD /////////
        public async Task<bool> CheckPassword(IdentityUser User, string Password)
        {
          var IsPasswordValid =  await _userManager.CheckPasswordAsync(User, Password);
            return IsPasswordValid;
        }
        ////////// FIND USER BY HIS USERNAME ////////////
        public async Task<IdentityUser?> FindUserByUserName(string UserName)
        {
           return await _userManager.FindByNameAsync(UserName);
        }
        /////// SIGN UP ///////
        public async Task<IdentityResult> RegisterUser(CreateUserDto UserDto)
        {
            var UserEntity = UserDto.ToUserEntity();
            IdentityResult result = await _userManager.CreateAsync(UserEntity,UserDto.Password);
            await _userManager.AddToRoleAsync(UserEntity, "Customer");

            return result;
        }
        //////// SIGN IN //////
        public async Task Signin(IdentityUser User, bool IsCookiePersistant)
        {
            //var UserEntity = UserExtentions.ToUserEntity(UserDto);
            await _signinManger.SignInAsync(User, IsCookiePersistant);
            var roles = await _userManager.GetRolesAsync(User);
        }
        //////// SIGN OUT ///////
        public async Task Signout()
        {
            await _signinManger.SignOutAsync();
        }
    }
}
