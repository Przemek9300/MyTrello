using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using trelloApi.Context;

namespace trelloApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly YettiContext _context;
        public ValuesController(YettiContext context)
        {
            _context = context;
        }

        // GET api/values

        [HttpGet]
        public List<Domains.User> Get()
        {
            _context.Users.Add(new Domains.User{Email="example",Avatar="/pics",HashPassword="hash",Salt=DateTime.Now.ToString()});
            _context.SaveChanges();
            return _context.Users.ToList();
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
