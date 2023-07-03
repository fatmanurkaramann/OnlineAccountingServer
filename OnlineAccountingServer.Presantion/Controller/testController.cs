using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Presantation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Presantation.Controller
{
    public sealed class testController:ApiController
    {

        [HttpGet]
        public IActionResult get()
        {
            return Ok();
        }
    }
}
