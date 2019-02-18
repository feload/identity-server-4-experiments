using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace DRHIdentityServer
{
    public class ApiResourcesRepository
    {
        public static IEnumerable<ApiResource> Get()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "customAPI",
                    DisplayName = "Custom API",
                    Description = "Custom API Access",
                    // List of associated user claim types that should be included in the access token.
                    UserClaims = new List<string> { "role" },
                    ApiSecrets = new List<Secret> { new Secret("scopeSecret".Sha256()) },
                    Scopes = new List<Scope>
                    {
                        new Scope("customAPI.read"),
                        new Scope("customAPI.write")
                    }
                }
            };
        }
    }
}
