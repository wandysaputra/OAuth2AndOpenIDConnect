using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure => 
        configure.JsonSerializerOptions.PropertyNamingPolicy = null);

// keeping the original claim types.. remove backward compatibility by Microsoft WS-Security standard
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ImageGalleryAPIRoot"]);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

/* To store the user's identity
 * `builder.Services.AddAuthentication` to configure authentication middleware
 */
builder.Services
    .AddAuthentication(options =>
    {
        // `options.DefaultScheme` by setting this value we can sign into, sign out and read scheme related information, simply by referring to this cookies scheme name. This is not strictly necessary. If you're hosting different applications on the same server, make sure that these have a different scheme name in order to avoid them interfering with each other.
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        // this will have to match the scheme we use to configure the OpenIDConnect
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    // this configure the cookie handler and it enables our application to use cookie-based authentication or our default scheme.
    // once an identity token is validated and transformed into a claim identity, it will be stored in an encrypted cookie, and that cookie is then used on subsequent requests to the web app to check whether or not we are making an authenticated request. In other word it's the cookie that is checked by our web app because we configure it like this.
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    // to register and configure the OpenID Connect handler.
    // This enables our application to support OpenID Connect Authentication workflow. It is this handler that will handle creating the authorization requests, token request, and other requests, and it will ensure that identity token validation happens.
    .AddOpenIdConnect(
        // This will ensure that when a part of our application requires authentication, OpenIDConnect will trigger as default as we set the `DefaultChallengeScheme` to OpenIDConnect as well. 
        OpenIdConnectDefaults.AuthenticationScheme 
        , options =>
        {
            // `SignInScheme` match with `DefaultScheme` name for Authentication
            // This ensures that the successfully result of authentication will be stored in the cookie matching this scheme.
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            
            // The Authority should be set to the address of our identity provider because that is the authority responsible for the identity provided part of the OpenID Connect flows.
            // The middleware will use this value to read the metadata on the discovery endpoint so it knows where to find the different endpoints and other information
            options.Authority = "https://localhost:5001/";

            // Should match the ClientId and ClientSecret at the level of the identity provider.
            options.ClientId = "imagegalleryclient";
            options.ClientSecret = "secret";

            // ResponseType corresponds to a grant or flow. PKCE enabled by default
            options.ResponseType = OpenIdConnectResponseType.Code;
            
            // Enables or disables the use of the Proof Key for Code Exchange (PKCE) standard.
            // This only applies when the "ResponseType" is set to "OpenIdConnectResponseType.Code".
            // The default value is `true`.
            // options.UsePkce = true;


            // Scopes we want to request. By default, openid and profile scopes are requested by the middleware
            // options.Scope.Add("openid");
            // options.Scope.Add("profile");

            // Should match the RedirectUris at the level of the identity provider. `signin-oidc` is the default value used by the middleware
            // options.CallbackPath = new PathString("signin-oidc");

            // This allows the middleware to save the tokens it receives from the identity provider.
            options.SaveTokens = true;


            // options.CallbackPath = new PathString("signin-oidc");
            // SignedOutCallbackPath: default = host:port/signout-callback-oidc.
            // Must watch with the post logout redirec URI at IDP client config if you want to automatically return to the application after logging out of IdentityServer. To change, set SignedOutCallbackPath, e.g. SignOutCallbackPath = "pathaftersignout"
            // options.SignedOutCallbackPath

            
            options.GetClaimsFromUserInfoEndpoint = true;

            // Manipulating the Claims Collection
            // default claims and its filters refer to https://github.com/dotnet/aspnetcore/blob/main/src/Security/Authentication/OpenIdConnect/src/OpenIdConnectOptions.cs
            options.ClaimActions.Remove("aud"); // this is remove default claim filter
            options.ClaimActions.DeleteClaim("sid"); // this is remove claim
            options.ClaimActions.DeleteClaim("idp"); // this is remove claim
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Setup authentication pipeline so the authentication middleware is effectively used
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Index}/{id?}");

app.Run();
