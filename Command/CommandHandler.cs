using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using trelloApi.Domains;
using trelloApi.Services;

namespace trelloApi.Command
{
    public class SignUp : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        public SignUp(IUserService userService) => _userService = userService;

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User login = new User();
            string tokenString = "";
            var user =  _userService.Authenticate(login);

            if (user != null)
            {
                tokenString = _userService.BuildToken(user);

            }

            return tokenString;
        }


    }
}