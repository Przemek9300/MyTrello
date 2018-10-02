using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using trelloApi.Command;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(int Id);
        string BuildToken(User user);
        User Authenticate(LoginCommand login);


        Task RegisterUser(RegisterCommand user);
        bool UserExist(string Email);
        bool BoardIsUnique(CreateBoardCommand command);
        void CreateBoard(Board board, int userId);
        Task SaveAsync();
        List<UserDTO> GetUsers();

        
        
    }
}