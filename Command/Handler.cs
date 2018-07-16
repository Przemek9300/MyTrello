using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using trelloApi.Domains;
using trelloApi.DTO;
using trelloApi.Services;

namespace trelloApi.Command
{
    public class LogIn : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        public LogIn(IUserService userService) => _userService = userService;

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
        
            string tokenString = "";
            
            var user = _userService.Authenticate(request);


            if (user != null)
            {
                tokenString = _userService.BuildToken(user);

            }

            return tokenString;
        }


    }

    public class Register : IRequestHandler<RegisterCommand, UserDTO>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public Register(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            
            var userDTO = _mapper.Map<UserDTO>(request);
            await _userService.RegisterUser(request);
            return userDTO;


        }


    }

}