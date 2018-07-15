using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using trelloApi.Domains;
using trelloApi.Services;

namespace trelloApi.Command
{
    public class LogIn : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        public LogIn(IUserService userService) => _userService = userService;

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User login = new User();
            string tokenString = "";
            var user = _userService.Authenticate(login);

            if (user != null)
            {
                tokenString = _userService.BuildToken(user);

            }

            return tokenString;
        }


    }

    public class Register : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public Register(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userService.RegisterUser(user);
            return "ok";


        }


    }

}