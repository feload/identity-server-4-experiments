using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace DRHIdentityServer
{
    public class IdentityResourcesRepository
    {
        public static IEnumerable<IdentityResource> Get()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    DisplayName = "Role",
                    Description = "Your role",
                    UserClaims = new List<string> { "role" }
               }
            };
        }
    }
}