using System;
using System.Collections.Generic;
using trelloApi.Domains;

namespace trelloApi.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; }
        public string Avatar { get; set; }
        public List<Board> Board { get; set; }
    }
}