using System;
using System.Threading.Tasks;
using trelloApi.Command;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task Add(User user);
        User Get(string email);
        string GetSalt(string email);
        Task SaveAsync();
        
    }
}