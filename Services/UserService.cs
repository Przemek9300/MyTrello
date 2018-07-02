using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trelloApi.Domains;

namespace trelloApi.Services

{
    public class UserSerivce:IUserService
    {
        private readonly IConfiguration _config;

        public UserSerivce(IConfiguration configuration)
        {
            _config = configuration;
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

        public User Authenticate(User login)
        {
            User user = new User();


            if (login.Email == "mario" && login.HashPassword == "secret")
            {
                user = new User { Avatar = "Mario Rossi", Email = "mario.rossi@domain.com" };
            }
            return user;
        }
        private IEnumerable<Claim> GetTokenClaims(User user)
        {
            return new List<Claim>
        {
        new Claim("UserName", "Gad"),
        new Claim("Email", "Gad"),
        new Claim("Name","Przem"),
        new Claim("Role","Admin")

            //More custom claims
        };
        }
    }
}