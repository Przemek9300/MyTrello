using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using trelloApi.Command;
using trelloApi.Domains;
using trelloApi.DTO;
using trelloApi.Repositories;

namespace trelloApi.Services

{
    public class UserSerivce : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;


        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        public UserSerivce(IConfiguration configuration, IUserRepository userRepositor, IMapper mapper, IPasswordService passwordService)
        {
            _mapper = mapper;
            _config = configuration;
            _userRepository = userRepositor;

            _passwordService = passwordService;
        }


        public string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],

              _config["Jwt:Issuer"],
              claims: GetTokenClaims(user),
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User Authenticate(LoginCommand login)
        {

            var user = _userRepository.Get(login.Email);
            if (user != null)
            {
                var salt = _userRepository.GetSalt(login.Email);
                var hash = _passwordService.GetHash(login.Password, salt);
                if (hash == user.HashPassword)
                    return user;



            }


            return null;
        }
        private List<Claim> GetTokenClaims(User user)
        {
            return new List<Claim>
        {

        new Claim("Id", user.UserId.ToString()),
        new Claim("Email", user.Email.ToString()),

            //More custom claims
        };
        }

        public async Task RegisterUser(RegisterCommand command)
        {
            var salt = _passwordService.GetSalt();
            var user = new User()
            {
                Email = command.Email,
                Salt = salt,
                HashPassword = _passwordService.GetHash(command.Password, salt),
                Avatar = ""

            };


            await _userRepository.Add(user);
            await _userRepository.SaveAsync();
        }

        public bool UserExist(string Email)
        {
            var user = _userRepository.Get(Email);
            if (user == null)
                return false;

            return true;
        }

        public async Task<UserDTO> GetUserAsync(int Id)
        {
            var user = await _userRepository.GetAsync(Id);
            if (user != null)
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            return null;
        }

        public void CreateBoard(Board Board, int userId)
        {
            _userRepository.CreateBoard(Board, userId);
        }

        public List<UserDTO> GetUsers() => _mapper.Map<List<UserDTO>>(_userRepository.GetUsers());

        public async Task SaveAsync()
        {
            await _userRepository.SaveAsync();
        }
    }
}