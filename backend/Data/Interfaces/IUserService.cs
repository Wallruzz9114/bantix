using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Data.Interfaces
{
    public interface IUserService
    {
        string Indentifier { get; }
        Guid GetAuthId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetPermissions();
    }
}