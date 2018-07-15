using System.Threading.Tasks;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Services
{
    public interface IUserService
    {
        string BuildToken(User user);
        User Authenticate(User login);
    
        Task RegisterUser(User user);
        bool UserExist(string Email);
        
    }
}