using BussinessLayer.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Mapping
{
    public static class UserExtentions
    {
        public static IdentityUser ToUserEntity (this CreateUserDto UserDto)
        {
            return new IdentityUser
            {
             UserName = UserDto.UserName,
             PasswordHash = UserDto.Password,
             
            };
        }
    }
}
