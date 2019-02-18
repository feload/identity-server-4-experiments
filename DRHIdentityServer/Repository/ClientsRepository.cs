using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace DRHIdentityServer
{
    public class ClientsRepository
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("superSecretPassword".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "customAPI.read"
                    }
                },

                new Client
                {
                    ClientId = "aplicativos_drh",
                    ClientName = "Aplicativos DRH.",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "customAPI.write"
                    },
                    RedirectUris = new List<string> {
                        "http://127.0.0.1:5500/aplicativos_drh/callback.html",
                        "http://127.0.0.1:5500/aplicativos_drh/silent.html",
                        "http://127.0.0.1:5500/aplicativos_drh/popup.html"
                    },
                    PostLogoutRedirectUris = new List<string> { "http://127.0.0.1:5500/aplicativos_drh/index.html" }
                }
            };
        }
    }
}
