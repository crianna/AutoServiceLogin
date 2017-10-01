using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace AutoServiceLogin
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");
            app.UseFacebookAuthentication(
            appId: "395662430833670",
            appSecret: "4acfb0e8d9901f2c6846f1dd60910c0a");

            var googleOAuth2AuthenticationOptions = new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationOptions
            {
                ClientId = "852013154203-somq7hs1p5makagbrq1fjuked4qofb0a.apps.googleusercontent.com",
                ClientSecret = "Qs1QLTNwAsLc-6Rmeg5GcKnr",
            };
            app.UseGoogleAuthentication(googleOAuth2AuthenticationOptions);
           
        }
    }
}