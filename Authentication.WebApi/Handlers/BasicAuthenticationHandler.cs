using Authentication.WebApi.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;

namespace Authentication.WebApi.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ApplicationDbContext context):base(options, logger, encoder, clock)
        {
            _context = context;
        }

        public ApplicationDbContext _context { get; }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //return AuthenticateResult.Fail("Need to impliment");

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Header Not Found");
            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string email = credentials[0];
                string password = credentials[1];

                var hashedPassword = new PasswordHasher<object?>().HashPassword(null, password);
                //var IsSignedIn = SignInManager.IsSignedIn(User);
                var user = _context.Users.Where(user => user.Email == email).FirstOrDefault();
                if (user != null)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.Email) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                    return AuthenticateResult.Fail("Invalid email or Password");
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Authentication Failed");
            }
        }

    }
}
