using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Presantation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Presantation.Controller
{
    public class CompaniesController : ApiController
    {
        public  CompaniesController(IMediator mediatr) : base(mediatr)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request )
        {
           CreateCompanyResponse response= await _mediatr.Send(request);
            return Ok(response);
        }
    }
}
