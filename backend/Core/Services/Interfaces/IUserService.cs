using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        string Indentifier { get; }
        Guid GetAuthId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetPermissions();
    }
}