using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using trelloApi.Command;
using trelloApi.Context;
using trelloApi.Domains;
using trelloApi.DTO;
using Microsoft.EntityFrameworkCore;

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
          var user =  _context.Users.Include(x=>x.Board).First(x=>x.UserId == id);

            return user;
        }

        public  User Get(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                var user = _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (user != null)
                    return user;
            }
            return null;
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


        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public async Task CreateBoardAsync(Board board, int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            board.User = user;

            user.Board.Add(board);
            await _context.Boards.AddAsync(board);
            _context.Entry(board).State = EntityState.Added;

            _context.Entry(user).State = EntityState.Modified;


            
            await _context.SaveChangesAsync();
        }
    }
}