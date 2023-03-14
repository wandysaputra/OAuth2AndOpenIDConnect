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
            // Access to your applications and resources, even when you are offline.
            // Offline in this context means the user is not logged in to the IDP
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
                Scopes =
                {
                    "imagegalleryapi.fullaccess",
                    "imagegalleryapi.read",
                    "imagegalleryapi.write"
                }
                , ApiSecrets = { new Secret("apisecret".Sha256()) }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("imagegalleryapi.fullaccess"),
            new ApiScope("imagegalleryapi.read"),
            new ApiScope("imagegalleryapi.write")
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
                // "imagegalleryapi.fullaccess",
                "imagegalleryapi.read",
                "imagegalleryapi.write",
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

            , IdentityTokenLifetime = (int) TimeSpan.FromMinutes(1).TotalSeconds // default 300 secs / 5 mins
            , AuthorizationCodeLifetime = (int) TimeSpan.FromMinutes(1).TotalSeconds  // default 300 secs / 5 mins
            , AccessTokenLifetime = (int) TimeSpan.FromMinutes(1).TotalSeconds  // default 3600 secs / 1 hour
            , AllowOfflineAccess = true // required to support refresh tokens
            , AbsoluteRefreshTokenLifetime = (int) TimeSpan.FromDays(1).TotalSeconds // Maximum lifetime of a refresh token in seconds. Defaults to 2592000 seconds / 30 days
            , RefreshTokenExpiration = TokenExpiration.Sliding // Absolute: the refresh token will expire on a fixed point in time (specified by the AbsoluteRefreshTokenLifetime). Sliding: when refreshing the token, the lifetime of the refresh token will be renewed (by the amount specified in SlidingRefreshTokenLifetime). The lifetime will not exceed AbsoluteRefreshTokenLifetime.
            , SlidingRefreshTokenLifetime = (int) TimeSpan.FromMinutes(2).TotalSeconds  // Sliding lifetime of a refresh token in seconds. Defaults to 1296000 seconds / 15 days
            , UpdateAccessTokenClaimsOnRefresh = true

            // Set Access Token to Reference Token
            , AccessTokenType = AccessTokenType.Reference
        }
    };
}