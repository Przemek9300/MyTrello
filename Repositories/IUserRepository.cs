using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using trelloApi.Command;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void CreateBoard(Board board, int userId);
        List<Board> GetBoard(int userID);
        Task<User> GetAsync(int id);
        Task Add(User user);
        User Get(string email);
        string GetSalt(string email);
        Task SaveAsync();

    }
}