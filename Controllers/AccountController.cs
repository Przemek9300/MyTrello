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
using System.IdentityModel.Tokens.Jwt;
using trelloApi.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trelloApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {


        private readonly IMediator _mediator;
        private readonly IUserService _userSerivce;

        public AccountController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userSerivce = userService;
        }


        public async Task<IActionResult> GetAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dto = await _userSerivce.GetUserAsync(int.Parse(userId));

            return Ok(dto);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]LoginCommand command)
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

        [AllowAnonymous]
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


        [HttpPost("boards")]
        
        public async Task<IActionResult> PostBoard([Bind("Title")]CreateBoardCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ModelState.SetModelValue("UserId", new ValueProviderResult(userId));

            command.UserId = int.Parse(userId);
            if (ModelState.IsValid)
            {
                var dto = await _mediator.Send(command);
                return Ok(dto);
            }

            
            return BadRequest(ModelState);
        }
        [HttpGet("boards")]
        public async Task<IActionResult> GetBoardsAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user  = await _userSerivce.GetUserAsync(int.Parse(userId));
            return Ok(user.Board);

        }



    }

}