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
    [Route("api/account")]
    public class AccountController : Controller
    {


        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

    
        [HttpPost]
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
        [HttpGet]
        public IActionResult Get()
        {

            var claims = User.Claims.Select(x => new { x.Type, x.Value }).ToList();


            IActionResult result;
            if (!User.Identity.IsAuthenticated)
            {
                return result = Unauthorized();
            }
            result = Ok(new { claims });
            return result;
        }
         [Route("api/register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterCommand command)
        {

           if(ModelState.IsValid){
               _mediator.Send(command);
               return Ok(command);
           }
           return BadRequest(ModelState);
        }
    }

}