using System.Collections.Generic;
using System.Security.Claims;

namespace Libraries.Abstraction.Interfaces
{
    public interface IAuthenticationHandler
    {
        string Identification { get; }
        int GetAuthenticatedUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetPermissions();
    }
}