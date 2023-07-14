using Microsoft.Extensions.Options;
using OnlineAccountingServer.Infrastructure.Authentication;

namespace OnlineAccountingServer.WebApi.OptionsSetup
{
    public sealed class JwtOptionsSetup : IConfigureOptions<JwtOption>
    {
        private readonly IConfiguration _configuration;
        private const string Jwt = nameof(Jwt);
        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOption options)
        {
            _configuration.GetSection(Jwt).Bind(options);
        }
    }
}
