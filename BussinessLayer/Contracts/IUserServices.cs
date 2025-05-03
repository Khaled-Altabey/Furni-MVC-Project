using BussinessLayer.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
    public interface IUserServices
    {
        Task<IdentityResult> RegisterUser(CreateUserDto UserDto);
        Task Signin(IdentityUser user, bool IsCookiePersistant);
        Task<IdentityUser?> FindUserByUserName (string UserName);
        Task<bool> CheckPassword(IdentityUser User , string Password);
        Task Signout();
    }
}
