using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Application.Features.AppFeatures.AppUserFeatures.Commands.Login;
using OnlineAccountingServer.Presantation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Presantation.Controller
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediatr) : base(mediatr)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
           LoginResponse res= await _mediatr.Send(req);
            return Ok(res);
        }
    }
}
