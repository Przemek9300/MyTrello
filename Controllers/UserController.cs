using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using trelloApi.Command;
using trelloApi.DTO;
using trelloApi.Services;

namespace trelloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userSerivce;

        public UsersController(IMediator mediator, IUserService userSerivce)
        {
            _mediator = mediator;
            _userSerivce = userSerivce;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var claims = User.Claims.SingleOrDefault(
        c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            return Ok(_userSerivce.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _userSerivce.GetUserAsync(id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }


        [HttpGet("{id}/boards")]
        public async Task<IActionResult> GetBoardsAsync(int id)
        {
            var user = await _userSerivce.GetUserAsync(id);
            if (user != null)
                return Ok(user.Board);
            return NotFound();
        }
      




    }
}