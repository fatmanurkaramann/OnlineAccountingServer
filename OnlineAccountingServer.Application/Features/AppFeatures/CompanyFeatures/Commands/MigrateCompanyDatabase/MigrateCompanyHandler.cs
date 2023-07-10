using MediatR;
using OnlineAccountingServer.Application.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyHandler : IRequestHandler<MigrateCompanyRequest, MigrateCompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyResponse> Handle
            (MigrateCompanyRequest request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return  new();
        }
    }
}
