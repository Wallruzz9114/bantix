using System;
using System.Collections.Generic;
using System.Security.Claims;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Data.Entities
{
    public class AppUser : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Indentifier => _httpContextAccessor.HttpContext.User.Identity.Name;

        public Guid GetAuthId()
        {
            return IsAuthenticated()
                ? Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name)
                : Guid.Empty;
        }

        public IEnumerable<Claim> GetPermissions()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            bool isAuthenticated;
            try
            {
                isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
            catch
            {
                isAuthenticated = false;
            }

            return isAuthenticated;
        }
    }
}