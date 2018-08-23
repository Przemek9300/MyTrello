using System;
using System.Collections.Generic;
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
        public UserRepository(YettiContext context, IMapper  mapper)
        {
         _context = context;   
        }

        async public Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetAsync(int id)
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


        public async Task AddBoard(Board board, Guid userID)
        {
           var user =  await _context.Users.FindAsync(userID);
           user.Board.Add(board);
        }

        public List<Board> GetBoard(int userID)
        {
            return _context.Boards.Where(x=>x.User.UserId == userID).ToList();
            
        }

        public void CreateBoard(Board board, int userId)
        {
            _context.Users.First(x=>x.UserId == userId).Board.Add(board);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}