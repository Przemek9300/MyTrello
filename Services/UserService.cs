using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using trelloApi.Domains;
using trelloApi.Repositories;

namespace trelloApi.Services

{
    public class UserSerivce:IUserService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public UserSerivce(IConfiguration configuration, IUserRepository userRepositor)
        {
            _config = configuration;
            _userRepository = userRepositor;
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

        public  User Authenticate(User login)
        {
            User user = new User(){Email="p",HashPassword="das",Id=Guid.NewGuid()};


            if (login.Email == "mario" && login.HashPassword == "secret")
            {
                user = new User { Avatar = "Mario Rossi", Email = "mario.rossi@domain.com" };
            }
            return user;
        }
        private List<Claim> GetTokenClaims(User user)
        {
            return new List<Claim>
        {
            
        new Claim("Id", user.Id.ToString()),
        new Claim("UserName", user.Email.ToString()),
        new Claim("Email", user.Email.ToString()),

            //More custom claims
        };
        }

        public async Task RegisterUser(User user)
        {
            
            await _userRepository.Add(user);
        }

        public bool UserExist(string Email)
        {
            var user = _userRepository.Get(Email);
            if(user==null)
                return false;
            return true;
        }
    }
}