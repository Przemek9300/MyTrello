using trelloApi.Domains;

namespace trelloApi.Services
{
    public interface IUserService
    {
        string BuildToken(User user);
        User Authenticate(User login);
    }
}