using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Application.Services.CompanyServices;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Persistance.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistance.Services.AppServices;
using OnlineAccountingServer.Persistance.Services.CompanyServices;
using OnlineAccountingServer.Persistance;

namespace OnlineAccountingServer.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<IUCAFService, UCAFService>();
        }
    }
}
