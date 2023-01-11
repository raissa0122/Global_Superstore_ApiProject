﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Models.Models;

namespace Services.Authentication
{
    public class AuthenticationService
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AuthenticationService(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<IdentityResult> RegisterAsync(string username, string password)
        {
            var user = new User
            {
                UserName = username,
            };

            var result = await this.userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return result;
            }

            await this.userManager.AddToRoleAsync(user, "user");

            return result;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null || !await this.userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }

            var role = await this.userManager.GetRolesAsync(user);
            IdentityOptions options = new IdentityOptions();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("UserName", user.UserName!),
                        new Claim(options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault()!)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWTKey"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
