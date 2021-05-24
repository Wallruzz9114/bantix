using System;
using System.Collections.Generic;
using System.Security.Claims;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Indentifier => _contextAccessor.HttpContext.User.Identity.Name;

        public Guid GetAuthId()
        {
            return IsAuthenticated()
                ? Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name)
                : Guid.Empty;
        }

        public IEnumerable<Claim> GetPermissions()
        {
            return _contextAccessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            var isAuthenticated = false;

            try
            {
                isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
            catch (Exception exception)
            {
                Log.Error($"Error while verifying authentication: ${ exception.Message }");
            }

            return isAuthenticated;
        }
    }
}