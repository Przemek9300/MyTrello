using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trelloApi.Services;
using trelloApi.Domains;
using MediatR;
using trelloApi.Command;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;

namespace trelloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {


        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Post(LoginCommand command)
        {

            ActionResult response = BadRequest();
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                {
                    response = Ok(new { TokenString = result });
                }
                return response;
            }
            return BadRequest(ModelState);
        }

    
       [HttpPost("register")]
        public async Task<IActionResult> Post(RegisterCommand command)
        {

            ActionResult response = BadRequest();
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                {
                    response = Ok(result);
                }
                return response;
            }
            return BadRequest(ModelState);
        }
    

       
    }
       
}