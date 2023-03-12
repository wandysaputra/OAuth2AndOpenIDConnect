using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace WestSouth.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            // Scope: OpenId
            // Claims: sub (user identifier)
            new IdentityResources.OpenId(),

            // Scope: Profile
            // Claims: name, family_name, given_name, middle_name, nickname, preferred_username, profile, picture, website, gender, birthdate, zoneinfo, locale, updated_at
            new IdentityResources.Profile()

            // Scope: Email
            // Claims: email, email_verified
            // , new IdentityResources.Email()

            // Scope: Address
            // Claims: address
            // , new IdentityResources.Address()

            // Scope: phone
            // Claims: phone_number, phone_number_verified
            // , new IdentityResources.Phone()

            // Scope: offline_access
            // Claims: doesn't map to any claim, but allow long-lived access.

            , new IdentityResource("roles", "Your role(s)", new[] { JwtClaimTypes.Role })

            , new IdentityResource("country", "The country you're living in", new[] { "country" })
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("imagegalleryapi"
                , "Image Gallery API"
                , new[] { JwtClaimTypes.Role, "country" })
            {
                Scopes = { "imagegalleryapi.fullaccess" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("imagegalleryapi.fullaccess")
        };

    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client
        {
            ClientName = "Image Gallery",
            ClientId = "imagegalleryclient",
            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris =
            {
                "https://localhost:7184/signin-oidc"
            }, 
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "roles",
                "imagegalleryapi.fullaccess",
                "country"
            }, 
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            }
            // Specifies whether a consent screen is required (defaults to false)
            , RequireConsent = true
            , PostLogoutRedirectUris =
            {
                "https://localhost:7184/signout-callback-oidc"
            }

            // should the user claims always be added to the id token instead of requiring the client to use the userinfo endpoint.
            // , AlwaysIncludeUserClaimsInIdToken = true
        }
    };
}