using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Application.Features.AppFeatures.AppUserFeatures.Commands.Login
{
    public sealed class LoginRequest:IRequest<LoginResponse>
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }

    }
}
