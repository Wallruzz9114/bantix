using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Core.ViewModels;
using Data.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities
{
    public static class TokenHandler
    {
        public static string CreateToken(UserViewModel userViewModel, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var randomKey = configuration.GetSection("Authentication").GetSection("SecretKey").Value;
            var secretKey = Encoding.ASCII.GetBytes(randomKey);
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
                        allClaims.Add(new Claim("cliente", "1"));
                        break;
                    }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new GenericIdentity(userViewModel.Id.ToString(), "Login"), allClaims),
                NotBefore = DateTime.UtcNow.AddMinutes(-15),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var secuityToken = tokenHandler.WriteToken(token);

            return secuityToken;
        }
    }
}