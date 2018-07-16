using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using trelloApi.Command;

namespace trelloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RegisterController:Controller
    {

     private readonly IMediator _mediator;
        public RegisterController (IMediator mediator)
        {
            _mediator = mediator;
        }
    
       [HttpPost]
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