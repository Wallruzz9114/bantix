using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Data.Enums;
using Data.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Utils
{
    public static class TokenHandler
    {
        public static string GenerateToken(UserViewModel userViewModel, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII
                .GetBytes(configuration.GetSection("Authentication").GetSection("secretKey").Value);

            var allClaims = new List<Claim>();

            switch (userViewModel.UserType)
            {
                case UserType.Agent:
                    {
                        allClaims.Add(new Claim("agent", "1"));
                        break;
                    }
                case UserType.Customer:
                    {
                        allClaims.Add(new Claim("customer", "1"));
                        break;
                    }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new GenericIdentity(userViewModel.Id.ToString(), "Login"),
                    allClaims
                ),
                NotBefore = DateTime.UtcNow.AddMinutes(-15),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}