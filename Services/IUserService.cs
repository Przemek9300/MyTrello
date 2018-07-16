using System.Threading.Tasks;
using trelloApi.Command;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Services
{
    public interface IUserService
    {
        string BuildToken(User user);
        User Authenticate(LoginCommand login);
    
        Task RegisterUser(RegisterCommand user);
        bool UserExist(string Email);
        
    }
}