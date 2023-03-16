using Duende.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WestSouth.IDP.DbContexts;
using WestSouth.IDP.Services;

namespace WestSouth.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // configures IIS out-of-proc settings
        builder.Services.Configure<IISOptions>(iisOptions =>
        {
            iisOptions.AuthenticationDisplayName = "Windows";
            iisOptions.AutomaticAuthentication = false;
        });
        // .. or configures IIS in-proc settings
        builder.Services.Configure<IISServerOptions>(iisServerOptions =>
        {
            iisServerOptions.AuthenticationDisplayName = "Windows";
            iisServerOptions.AutomaticAuthentication = false; // disable the IIS integration layer configuring Windows Authentication handlers that can be invoked via an authentication service. We want to integration happen via our own custom code.
        });

        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<IPasswordHasher<Entities.User>, PasswordHasher<Entities.User>>();

        builder.Services.AddScoped<ILocalUserService, LocalUserService>();

        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("WestSouthIdentityDBConnectionString"));
        });

        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
            })
            .AddProfileService<LocalUserProfileService>()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients);

        builder.Services
            .AddAuthentication()
            .AddOpenIdConnect("AAD", "Azure Active Directory", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.Authority = "https://login.microsoftonline.com/621cb4b2-eeb8-4699-913d-a651c392babd/v2.0"; // Directory/TenantId Azure AD get from discovery end-point Azure AD of issuer's value
                options.ClientId = "df55658d-e228-4f72-9f11-b60334edb0e2"; // Client Id Azure AD
                options.ClientSecret = "Tkt8Q~gJ9yez1EGA6BqFJfCVWIzM_B.bCAUx8bkB"; // Client Secret Azure AD
                options.ResponseType = "code"; // default by Azure AD
                options.CallbackPath = new PathString("/signin-aad/"); // SignIn Path in Azure AD
                options.SignedOutCallbackPath = new PathString("/signout-aad/");  // SignOut Path in Azure AD
                options.Scope.Add("email"); // matches permission setup by Ms Graph 
                options.Scope.Add("offline_access");  // matches permission setup by Ms Graph 
                options.SaveTokens = true;
            });


        builder.Services.AddAuthentication()
            .AddFacebook("Facebook",
                options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.AppId = "864396097871039";
                    options.AppSecret = "11015f9e340b0990b0e50f39dd8a4e9a";
                });

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
