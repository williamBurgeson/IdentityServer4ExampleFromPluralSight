using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace SecuringAngularApps.STS
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("projects-api", "Projects API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            string ngAppRoot = "http://localhost:4199";
            string electronRoot = "http://localhost:4200";
            //string electronRoot = "file://C:/DevWork/Experimental/IdentityServer4ExampleFromPluralSight/ElectronClient/dist";
            return new List<Client>
            {
                new Client
                {
                    ClientId = "spa-client",
                    ClientName = "Projects SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris =           { $"{ngAppRoot}/assets/oidc-login-redirect.html", $"{ngAppRoot}/assets/silent-redirect.html" },
                    PostLogoutRedirectUris = { $"{ngAppRoot}/?postLogout=true" },
                    AllowedCorsOrigins =     { ngAppRoot + "/" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "projects-api"
                    },
                    IdentityTokenLifetime=120,
                    AccessTokenLifetime=120
                },
                new Client
                {
                    ClientId = "electron-client",
                    ClientName = "Projects SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris =           { $"{electronRoot}/assets/oidc-login-redirect.html", $"{electronRoot}/assets/silent-redirect.html" },
                    PostLogoutRedirectUris = { $"{electronRoot}/post-logout.html" },
                    AllowedCorsOrigins =     { electronRoot + "/" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "projects-api"
                    },
                    IdentityTokenLifetime=120,
                    AccessTokenLifetime=120

                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "https://localhost:4201/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:4201/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowOfflineAccess = true

                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
            }
        }
    }