using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.Keycloak;

[assembly: OwinStartup(typeof(MVC_Keycloak.Startup))]

namespace MVC_Keycloak
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Name of the persistent authentication middleware for lookup
            const string persistentAuthType = "MVC_Keycloak_cookie_auth";

            // --- Cookie Authentication Middleware - Persists user sessions between requests
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = persistentAuthType
            });
            app.SetDefaultSignInAsAuthenticationType(persistentAuthType); // Cookie is primary session store

            // --- Keycloak Authentication Middleware - Connects to central Keycloak database
            app.UseKeycloakAuthentication(new KeycloakAuthenticationOptions
            {
                // App-Specific Settings
                ClientId = "keycloak-asp-net", // *Required*
                ClientSecret = "7681018a-f8c6-4d3e-bc06-5a84f079a7e3", // If using public authentication, delete this line
                VirtualDirectory = "", // Set this if you use a virtual directory when deploying to IIS

                // Instance-Specific Settings
                Realm = "Realm1", // Don't change this unless told to do so
                KeycloakUrl = "http://localhost:8180/auth", // Enter your Keycloak URL here

                // Template-Specific Settings
                SignInAsAuthenticationType = persistentAuthType, // Sets the above cookie with the Keycloak data
                AuthenticationType = "MVC_Keycloak_keycloak_auth", // Unique identifier for the auth middleware
            });
        }
    }
}
//https://github.com/dylanplecki/KeycloakOwinAuthentication/wiki/ASP.NET-MVC-Tutorial