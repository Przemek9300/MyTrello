using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trelloApi.Services;
using trelloApi.Domains;

namespace trelloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public IActionResult Post()
        {
            User login = new User();
            IActionResult response = Unauthorized();
            var user = _userService.Authenticate(login);

            if (user != null)
            {
                var tokenString = _userService.BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}