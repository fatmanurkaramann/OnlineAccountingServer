using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Application.Services.CompanyServices
{
    public interface IUCAFService
    {
        Task CreateUCAFAsync(CreateUCAFRequest request);
    }
}
