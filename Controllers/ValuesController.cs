using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using trelloApi.Context;
using MediatR;
using System.Security.Claims;

namespace trelloApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller

    {
        private readonly ClaimsPrincipal _caller;

        private readonly IMediator _mediator;
        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [Authorize]
        [HttpGet]
        public string Get()
        {

            var userId = User.Claims.First(x=> x.Type=="Id").Value;
            
            return "test";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
