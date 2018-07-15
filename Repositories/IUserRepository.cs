using System;
using System.Threading.Tasks;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetAsync(Guid id);
        Task Add(User user);
        UserDTO Get(string email);
        
    }
}