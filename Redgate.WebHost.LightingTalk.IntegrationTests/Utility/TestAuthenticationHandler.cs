using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Redgate.WebHost.LightingTalk.IntegrationTests.Utility
{
    public class TestAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public string Role { get; set; }
    }

    public class TestAuthenticationHandler : AuthenticationHandler<TestAuthenticationSchemeOptions>
    {
        public TestAuthenticationHandler(IOptionsMonitor<TestAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) :
            base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "TestName"),
                new Claim(ClaimTypes.Role, Options.Role),
            };

            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);

            var authTicket = new AuthenticationTicket(principal, "Test");

            return  Task.FromResult(AuthenticateResult.Success(authTicket)); 
        }
    }
}