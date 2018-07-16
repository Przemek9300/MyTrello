using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using trelloApi.Command;
using trelloApi.Context;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YettiContext _context;
        private readonly IMapper  _mapper;
        public UserRepository(YettiContext context, IMapper  mapper)
        {
         _context = context;   
         _mapper = mapper;
        }

        async public Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetAsync(Guid id)
        {
          var user = await _context.Users.FindAsync(id);
           return user;
        }

        public  User Get(string email)
        {
            var user =  _context.Users.FirstOrDefault(x=>x.Email.ToLower()==email.ToLower());
            if(user==null)
                return null;
            
            return user;
        }

        public string GetSalt(string email)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Email.ToLower()==email.ToLower());
            if(user==null)
                return null;
            
            return user.Salt;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}