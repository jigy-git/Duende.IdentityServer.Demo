﻿using Duende.IdentityServer.Models;

namespace IdentityServer;
public static class Config
{    
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource

             {

                 Name = "role",

                 UserClaims = new List<string> {"role"}

             },
    ];

    public static IEnumerable<ApiScope> ApiScopes =>       
    [
        new ApiScope("weatherapi.read"),
        new ApiScope("weatherapi.write"),
        new ApiScope("test"),
    ];

    public static IEnumerable<ApiResource> ApiResources =>
    [
        // m2m client credentials flow client
        new ApiResource("weatherapi")
        {
            Scopes = new List<string> { "weatherapi.read", "weatherapi.write" },
            ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256())},
            UserClaims = new List<string> {"role"}
        }
    ];

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                AllowedScopes = {  "weatherapi.read", "weatherapi.write", "test" }
            },
            
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "Http://localhost:7259/signin-oidc" },
                FrontChannelLogoutUri ="https://localhost:7276/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7276/signout-callback-oidc" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "weatherapi.read", "weatherapi.write" }
            },
        };
}