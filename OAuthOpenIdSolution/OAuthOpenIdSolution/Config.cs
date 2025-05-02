using Duende.IdentityServer.Models;

namespace AuthServer
{
    public static class Config
    {
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "angular-client",
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "http://localhost:4200/callback" },
                PostLogoutRedirectUris = { "http://localhost:4200" },
                AllowedScopes = { "openid", "profile", "api1" },
                RequirePkce = true,
                RequireClientSecret = false,
                AllowedCorsOrigins = { "http://localhost:4200" },
                AllowAccessTokensViaBrowser = true
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] { new("api1", "My API") };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
            };
    }
}
