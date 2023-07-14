using OnlineAccountingServer.Application.Abstractions;
using OnlineAccountingServer.Infrastructure.Authentication;

namespace OnlineAccountingServer.WebApi.Configurations
{
    public class InfrastructureDIService : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();

        }
    }
}
